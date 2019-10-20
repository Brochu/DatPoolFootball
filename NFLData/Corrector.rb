require 'json'
require 'active_support/core_ext/hash'

def getWeekScore(weekData)
    return 1;
end

def printWeekScores(scoresData)
    puts scoresData;
end

def printTotalScores(scoresArray)
    scoresArray.each { |s| 
        if (s != nil)
            puts s;
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