require 'net/http'
require 'time'

require 'json'

if (ARGV.length == 2)
    season = ARGV[0];
    week = ARGV[1];

    uri = URI("https://www.thesportsdb.com/api/v1/json/1/eventsround.php?id=4391&r=#{week}&s=#{season}");

    result = Net::HTTP.get(uri);

    weekData = JSON.parse(result);
    games = weekData["events"];
    games.each do |game|
        game.delete("idEvent");
        game.delete("idSoccerXML");
        game.delete("idAPIfootball");
        game.delete("strEvent");
        game.delete("strEventAlternate");
        game.delete("strFilename");
        game.delete("strSport");
        game.delete("idLeague");
        game.delete("strLeague");
        game.delete("strSeason");
        game.delete("strDescriptionEN");
        game.delete("intRound");
        game.delete("intSpectators");
        game.delete("strOfficial");
        game.delete("strHomeGoalDetails");
        game.delete("strHomeRedCards");
        game.delete("strHomeYellowCards");
        game.delete("strHomeLineupGoalkeeper");
        game.delete("strHomeLineupDefense");
        game.delete("strHomeLineupMidfield");
        game.delete("strHomeLineupForward");
        game.delete("strHomeLineupSubstitutes");
        game.delete("strHomeFormation");
        game.delete("strAwayGoalDetails");
        game.delete("strAwayRedCards");
        game.delete("strAwayYellowCards");
        game.delete("strAwayLineupGoalkeeper");
        game.delete("strAwayLineupDefense");
        game.delete("strAwayLineupMidfield");
        game.delete("strAwayLineupForward");
        game.delete("strAwayLineupSubstitutes");
        game.delete("strAwayFormation");
        game.delete("intHomeShots");
        game.delete("intAwayShots");
        game.delete("strTimestamp");
        game.delete("dateEventLocal");
        game.delete("strDate");
        game.delete("strTime");
        game.delete("strTVStation");
        game.delete("idHomeTeam");
        game.delete("idAwayTeam");
        game.delete("strResult");
        game.delete("strVenue");
        game.delete("strCountry");
        game.delete("strCity");
        game.delete("strPoster");
        game.delete("strFanart");
        game.delete("strThumb");
        game.delete("strBanner");
        game.delete("strMap");
        game.delete("strTweet1");
        game.delete("strTweet2");
        game.delete("strTweet3");
        game.delete("strVideo");
        game.delete("strStatus");
        game.delete("strPostponed");
        game.delete("strLocked");
    end

    filename = "pool-#{season}-#{week}.json"
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
    puts "NEED TO SPECIFY SEASON, WEEK";
end
