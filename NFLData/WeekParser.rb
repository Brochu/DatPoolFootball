require 'net/http'
require 'rexml/document'
require 'time'

require 'json'
require 'active_support/core_ext/hash'

include REXML

if (ARGV.length == 3)
    season = ARGV[0];
    week = ARGV[1];
    type = ARGV[2];

    uri = URI("http://www.nfl.com/ajax/scorestrip?season=#{season}&week=#{week}&seasonType=#{type}");

    result = Net::HTTP.get(uri);

    weekData = JSON.parse(Hash.from_xml(result).to_json);
    games = weekData["ss"]["gms"]["g"];
    games.each do |game|
        game.delete("eid");
        game.delete("gsis");
        game.delete("k");
        game.delete("p");
        game.delete("rz");
        game.delete("ga");
    end

    filename = "pool-#{season}-#{week}-#{type}.json"
    outputObj = {};
    if (File.exists?(filename))
        outputObj = JSON.parse(File.read(filename));
        outputObj["games"] = games;
    else
        outputObj = {
            :games => games,
            :predictions => []
        }
    end

    file = File.open(filename, "w");
    file.write(JSON.pretty_generate(outputObj));
    file.close();
else
    puts "NEED TO SPECIFY SEASON, WEEK AND TYPE";
end
