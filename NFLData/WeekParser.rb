require 'net/http'
require 'rexml/document'
require 'time'
include REXML

if (ARGV.length < 2)
    puts "NEED TO SPECIFY SEASON AND WEEK";
else
    season = ARGV[0];
    week = ARGV[1];
    type = "REG";
    #puts "Looking at season #{season} and week #{week}";

    uri = URI("http://www.nfl.com/ajax/scorestrip?season=#{season}&week=#{week}&seasonType=#{type}");
    #puts "Fetching from uri : #{uri}";

    result = Net::HTTP.get(uri);
    xmlDoc = Document.new(result);
    xmlDoc.get_elements("//g").each do |game|
        home = game.attribute("h");
        homeScore = game.attribute("hs");
        away = game.attribute("v");
        awayScore = game.attribute("vs");

        weekDay = game.attribute("d");
        startTime = Time.parse("#{game.attribute("t")}");
        startTime = startTime + (60 * 60 * 12);

        puts "new Match { Season = #{season}, Week = #{week}, HomeTeamId = \"#{home}\", HomeScore = #{homeScore}, AwayTeamId = \"#{away}\", AwayScore = #{awayScore}, WeekDay = Day.#{weekDay}, StartTime = DateTime.Parse(\"#{startTime.strftime("%H:%M")}\") },";
    end

    xmlDoc.get_elements("//g").each do |game|
        home = game.attribute("h");
        away = game.attribute("v");

	puts "#{away} vs. #{home}"
    end
end
