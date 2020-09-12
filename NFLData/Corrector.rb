require 'json'
require 'active_support/core_ext/hash'

def getWeekScore(weekData)
    weekData["games"].each_with_index do |game, i|
        homeUnique = weekData["predictions"].one? do |p|
            p["picks"][i] == game["h"];
        end
        visitUnique = weekData["predictions"].one? do |p|
            p["picks"][i] == game["v"];
        end

        weekData["predictions"].each do |p|
            result = 0;
            homeScore = game["hs"].to_i();
            visitScore = game["vs"].to_i();

            if (homeScore == visitScore)
                result = (game["q"] != "P") ? 1 : 0;

            elsif (homeScore > visitScore && p["picks"][i] == game["h"])
                result = (homeUnique) ? 3 : 2;

            elsif (visitScore > homeScore && p["picks"][i] == game["v"])
                result = (visitUnique) ? 3 : 2;
            end

            if (p[:result] != nil)
                p[:result] += result;
            else
                p[:result] = result;
            end
        end
    end

    return weekData;
end

def printWeekScores(scoresData)
    scoresData["games"].each_with_index do |game, i|
        gameStr = "#{game["v"]} (#{game["vs"]}) vs. (#{game["hs"]}) #{game["h"]} | ";
        scoresData["predictions"].each do |p|
            gameStr.concat("#{p["pooler"]}: #{p["picks"][i]} -- ");
        end

        puts gameStr;
    end

    totals = scoresData["predictions"].map do |p|
        # "#{p["pooler"]}: #{p[:result]} points"
        { :pooler => p["pooler"], :result => p[:result] };
    end

    puts "This week: #{JSON.pretty_generate(totals)}";
    return totals
end

def printTotalScores(scoresArray)
    grandTotal = nil;
    scoresArray.each do |s|
        if (grandTotal == nil)
            grandTotal = printWeekScores(s);
        else
            total = printWeekScores(s);
            total.each do |t|
                entry = grandTotal.find { |g| g[:pooler] == t[:pooler] };
                entry[:result] += t[:result];
            end
        end
    end

    puts "";
    puts "GRAND TOTALS: #{JSON.pretty_generate(grandTotal)}";
end

if (ARGV.length == 2)
    season = ARGV[0];
    week = ARGV[1];

    # GET WEEK FILE AND APPLY CORRECTIONS
    filename = "pool-#{season}-#{week}.json"
    scores = getWeekScore(JSON.parse(File.read(filename)));
    printWeekScores(scores);

elsif (ARGV.length == 1)
    season = ARGV[0];

    filepaths = (1..21).map { |w| "pool-#{season}-#{w}.json" };
    scoresArray = filepaths.map do |file|
        if (File.exists?(file))
            getWeekScore(JSON.parse(File.read(file)));
        else
            nil;
        end
    end
    printTotalScores(scoresArray.compact);

else
    puts "NEED TO SPECIFY SEASON AND WEEK OR SEASON";
end
