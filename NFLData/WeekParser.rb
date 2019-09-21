require 'net/http'
require 'rexml/document'
require 'time'

require 'json'
require 'active_support/core_ext/hash'

include REXML

if (ARGV.length < 3 || ARGV.length > 3)
    puts "NEED TO SPECIFY SEASON, WEEK AND TYPE";
else
    season = ARGV[0];
    week = ARGV[1];
    type = ARGV[2];
    #puts "Looking at season #{season} and week #{week}";

    uri = URI("http://www.nfl.com/ajax/scorestrip?season=#{season}&week=#{week}&seasonType=#{type}");
    #puts "Fetching from uri : #{uri}";

    result = Net::HTTP.get(uri);

    weekData = JSON.parse(Hash.from_xml(result).to_json);
    games = weekData["ss"]["gms"]["g"];
    games.each do |game|
        puts "#{game["hnn"]} #{game["hs"]} vs. #{game["vs"]} #{game["vnn"]}";
    end
end
