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

        element["picks"] = picks;
        result.push(element);
    end

    return result;
end

def printWeekScores(scoresData)
    puts JSON.pretty_generate(scoresData);
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
