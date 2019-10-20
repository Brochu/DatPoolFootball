require 'json'
require 'active_support/core_ext/hash'

if (ARGV.length < 3 || ARGV.length > 3)
    puts "NEED TO SPECIFY SEASON, WEEK AND TYPE";
else
    season = ARGV[0];
    week = ARGV[1];
    type = ARGV[2];

    # GET WEEK FILE AND APPLY CORRECTIONS
    filename = "pool-#{season}-#{week}-#{type}.txt"
end
