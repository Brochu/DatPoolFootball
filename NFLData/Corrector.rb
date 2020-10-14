require 'json'

def getWeekScore(weekData)
    weekData["games"].each_with_index do |game, i|
        homeUnique = weekData["predictions"].one? do |p|
            p["picks"][i] == "H";
        end
        visitUnique = weekData["predictions"].one? do |p|
            p["picks"][i] == "V";
        end

        weekData["predictions"].each do |p|
            result = 0;
            homeScore = (game["intHomeScore"] != nil) ? game["intHomeScore"].to_i() : nil;
            visitScore = (game["intAwayScore"] != nil) ? game["intAwayScore"].to_i() : nil;

            if (homeScore == visitScore)
                result = (homeScore != nil && visitScore != nil) ? 1 : 0;

            elsif (homeScore > visitScore && p["picks"][i] == "H")
                result = (homeUnique) ? 3 : 2;

            elsif (visitScore > homeScore && p["picks"][i] == "V")
                result = (visitUnique) ? 3 : 2;
            end

            if (p[:result] != nil)
                p[:result] += result;
            else
                p[:result] = result;
            end

            if (p[:scores] != nil)
                p[:scores].push(result);
            else
                p[:scores] = Array.new(1, result);
            end
        end
    end

    return weekData;
end

def printWeekScores(scoresData)
    scoresData["games"].each_with_index do |game, i|
        gameStr = "#{game["strAwayTeam"].ljust(20)} (#{game["intAwayScore"].to_s.rjust(2)})";
        gameStr.concat(" vs. ");
        gameStr.concat("(#{game["intHomeScore"].to_s.rjust(2)}) #{game["strHomeTeam"].rjust(20)} | ");
        scoresData["predictions"].each do |p|
            gameStr.concat("#{p["pooler"]}: +#{p[:scores][i]} -- ");
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
                if (entry != nil) 
                  entry[:result] += t[:result];
                end
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
