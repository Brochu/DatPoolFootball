require 'json'
require 'active_support/core_ext/hash'

if (ARGV.length < 4 || ARGV.length > 4)
    puts "NEED TO SPECIFY SEASON, WEEK AND TYPE AND PICKS STRING";
else
    season = ARGV[0];
    week = ARGV[1];
    type = ARGV[2];
    pickString = ARGV[3];

    # PARSE PICKS AND ADD/UPDATE TO CORRECT WEEK
    filename = "pool-#{season}-#{week}-#{type}.txt"
end
