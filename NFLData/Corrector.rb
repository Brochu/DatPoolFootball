require 'json'
require 'active_support/core_ext/hash'

def getWeekScore(weekData)
    result = [];
    weekData["games"].each_with_index do |g, i|
        element = { :game => g };
        picks = [];

        weekData["predictions"].each do |p|
            picks.push({
                :pooler => p["pooler"],
                :pick => p["picks"][i]
            });
        end

        element[:picks] = picks;
        result.push(element);
    end

    return result;
end

def printWeekScores(scoresData)
    totals = [];
    scoresData.each do |score|
        matchString = "#{score[:game]["v"]} (#{score[:game]["vs"]}) | #{score[:game]["h"]} (#{score[:game]["hs"]}) -- ";

        homeUniqueCheck = score[:picks].one? do |p|
            p[:pick] == score[:game]["h"];
        end
        visitUniqueCheck = score[:picks].one? do |p|
            p[:pick] == score[:game]["v"];
        end

        score[:picks].each { |p| 
            matchString.concat("#{p[:pooler]}:#{p[:pick]} | ");
            t = totals.find { |e| e[:pooler] == p[:pooler] };

            scoreToAdd = 0;
            if (score[:game]["hs"].to_i == score[:game]["vs"].to_i)
                scoreToAdd = 1;

            elsif (score[:game]["hs"].to_i > score[:game]["vs"].to_i &&
            p[:pick] == score[:game]["h"])
                if (homeUniqueCheck)
                    scoreToAdd = 3;
                else
                    scoreToAdd = 2;
                end

            elsif (score[:game]["vs"].to_i > score[:game]["hs"].to_i &&
            p[:pick] == score[:game]["v"])
                if (visitUniqueCheck)
                    scoreToAdd = 3;
                else
                    scoreToAdd = 2;
                end
            end

            if (t != nil)
                t[:score] += scoreToAdd;
            else
                totals.push({
                    :pooler => p[:pooler],
                    :score => scoreToAdd
                });
            end
        };
        puts matchString;
    end

    puts totals;

    # Return to make the grand total calculation easier down the line
    return totals;
end

def printTotalScores(scoresArray)
    scoresArray.each { |s| 
        if (s != nil)
            puts JSON.pretty_generate(s);
        end
    };
end

if (ARGV.length == 3)
    season = ARGV[0];
    week = ARGV[1];
    type = ARGV[2];

    # GET WEEK FILE AND APPLY CORRECTIONS
    filename = "pool-#{season}-#{week}-#{type}.json"
    scores = getWeekScore(JSON.parse(File.read(filename)));
    printWeekScores(scores);

elsif (ARGV.length == 2)
    season = ARGV[0];
    type = ARGV[1];

    filepaths = (1..17).map { |w| "pool-#{season}-#{w}-#{type}.json" };
    scoresArray = filepaths.map { |file|
        if (File.exists?(file))
            getWeekScore(JSON.parse(File.read(file)));
        else
            nil;
        end
    };
    printTotalScores(scoresArray);

else
    puts "NEED TO SPECIFY SEASON, WEEK AND TYPE OR SEASON AND TYPE";
end
