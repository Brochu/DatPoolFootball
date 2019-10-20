require 'json'
require 'active_support/core_ext/hash'

if (ARGV.length == 4)
    season = ARGV[0];
    week = ARGV[1];
    type = ARGV[2];
    picksFile = ARGV[3];

    # PARSE PICKS AND ADD/UPDATE TO CORRECT WEEK
    # Picks format: { :pooler => "NAME", :picks => [ AAA, AAB, AAC, (...) ] }
    filename = "pool-#{season}-#{week}-#{type}.json";
    if (!File.exists?(filename) || !File.exists?(picksFile))
        puts "COULD NOT FIND FILE #{filename} OR #{picksFile}";
    else
        picksData = JSON.parse(File.read(picksFile));
        weekData = JSON.parse(File.read(filename));

        currentPicks = weekData["predictions"].detect { |e| e["pooler"] == picksData["pooler"] };
        currentPicks["picks"] = picksData["picks"];

        file = File.open(filename, "w");
        file.write(JSON.pretty_generate(weekData));
        file.close();
    end
else
    puts "NEED TO SPECIFY SEASON, WEEK AND TYPE AND PICKS STRING";
end
