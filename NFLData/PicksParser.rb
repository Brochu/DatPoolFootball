require 'json'
require "base64"

if (ARGV.length == 3)
    season = ARGV[0];
    week = ARGV[1];
    picks64 = ARGV[2];

    # PARSE PICKS AND ADD/UPDATE TO CORRECT WEEK
    # Picks format: { :pooler => "NAME", :picks => [ AAA, AAB, AAC, (...) ] }
    filename = "pool-#{season}-#{week}.json";
    if (!File.exists?(filename))
        puts "COULD NOT FIND FILE #{filename}";
    else
        picksData = JSON.parse(Base64.decode64(picks64));
        weekData = JSON.parse(File.read(filename));

        currentPicks = weekData["predictions"].detect { |e| e["pooler"] == picksData["pooler"] };
        if (currentPicks != nil)
            currentPicks["picks"] = picksData["picks"];
        else
            weekData["predictions"].push({
                "pooler" => picksData["pooler"],
                "picks" => picksData["picks"]
            });
        end

        file = File.open(filename, "w");
        file.write(JSON.pretty_generate(weekData));
        file.close();
    end
else
    puts "NEED TO SPECIFY SEASON, WEEK AND PICKS STRING";
end
