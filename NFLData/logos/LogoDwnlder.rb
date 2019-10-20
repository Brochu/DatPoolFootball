require 'open-uri'

urls = [
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/NE.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/MIA.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/BUF.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/NYJ.svg',

    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/BAL.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/PIT.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/CLE.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/CIN.svg',

    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/HOU.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/IND.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/TEN.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/JAX.svg',

    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/KC.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/LAC.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/DEN.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/OAK.svg',

    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/DAL.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/PHI.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/WAS.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/NYG.svg',

    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/CHI.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/MIN.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/GB.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/DET.svg',

    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/NO.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/ATL.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/CAR.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/TB.svg',

    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/LA.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/SEA.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/SF.svg',
    'https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/ARI.svg'
];

filenames = urls.map { |url|
    url[(url.rindex('/')+1)..url.length];
}

(0...urls.length).each { |i|
    puts "Downloading from #{urls[i]}"
    download = open(urls[i], {ssl_verify_mode: 0});
    IO.copy_stream(download, "logos/#{filenames[i]}");
    puts "Saved to #{filenames[i]}"
}