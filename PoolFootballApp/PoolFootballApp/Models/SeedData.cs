using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace PoolFootballApp.Models
{
	public class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (NFLContext Nfl = new NFLContext(
				serviceProvider.GetRequiredService<DbContextOptions<NFLContext>>()
			))
			{
				PopulateTeams(Nfl);
				PopulateMatches(Nfl);
				Nfl.SaveChanges();
			}
		}

		private static void PopulateTeams(NFLContext Nfl)
		{
			if (Nfl.Teams.Any())
			{
				// Database was already seeded
				return;
			}

			Nfl.Teams.AddRange(

				// AFC EAST
				new Team { Name = "Patriots", City = "New England", Conf = Conference.AFC, Div = Division.East, ShortName = "NE" },
				new Team { Name = "Dolphins", City = "Miami", Conf = Conference.AFC, Div = Division.East, ShortName = "MIA" },
				new Team { Name = "Bills", City = "Buffalo", Conf = Conference.AFC, Div = Division.East, ShortName = "BUF" },
				new Team { Name = "Jets", City = "New York", Conf = Conference.AFC, Div = Division.East, ShortName = "NYJ" },

				// AFC NORTH
				new Team { Name = "Ravens", City = "Baltimore", Conf = Conference.AFC, Div = Division.North, ShortName = "BAL" },
				new Team { Name = "Steelers", City = "Pittsburgh", Conf = Conference.AFC, Div = Division.North, ShortName = "PIT" },
				new Team { Name = "Browns", City = "Cleveland", Conf = Conference.AFC, Div = Division.North, ShortName = "CLE" },
				new Team { Name = "Bengals", City = "Cincinnati", Conf = Conference.AFC, Div = Division.North, ShortName = "CIN" },

				// AFC SOUTH
				new Team { Name = "Texans", City = "Houston", Conf = Conference.AFC, Div = Division.South, ShortName = "HOU" },
				new Team { Name = "Colts", City = "Indianapolis", Conf = Conference.AFC, Div = Division.South, ShortName = "IND" },
				new Team { Name = "Titans", City = "Tennessee", Conf = Conference.AFC, Div = Division.South, ShortName = "TEN" },
				new Team { Name = "Jaguars", City = "Jacksonville", Conf = Conference.AFC, Div = Division.South, ShortName = "JAX" },

				// AFC WEST
				new Team { Name = "Chiefs", City = "Kansas City", Conf = Conference.AFC, Div = Division.West, ShortName = "KC" },
				new Team { Name = "Chargers", City = "Los Angeles", Conf = Conference.AFC, Div = Division.West, ShortName = "LAC" },
				new Team { Name = "Broncos", City = "Denver", Conf = Conference.AFC, Div = Division.West, ShortName = "DEN" },
				new Team { Name = "Raiders", City = "Oakland", Conf = Conference.AFC, Div = Division.West, ShortName = "OAK" },

				// NFC EAST
				new Team { Name = "Cowboys", City = "Dallas", Conf = Conference.NFC, Div = Division.East, ShortName = "DAL" },
				new Team { Name = "Eagles", City = "Philadelphia", Conf = Conference.NFC, Div = Division.East, ShortName = "PHI" },
				new Team { Name = "Redskins", City = "Washington", Conf = Conference.NFC, Div = Division.East, ShortName = "WAS" },
				new Team { Name = "Giants", City = "New York", Conf = Conference.NFC, Div = Division.East, ShortName = "NYG" },

				// NFC NORTH
				new Team { Name = "Bears", City = "Chicago", Conf = Conference.NFC, Div = Division.North, ShortName = "CHI" },
				new Team { Name = "Vikings", City = "Minnesota", Conf = Conference.NFC, Div = Division.North, ShortName = "MIN" },
				new Team { Name = "Packers", City = "Green Bay", Conf = Conference.NFC, Div = Division.North, ShortName = "GB" },
				new Team { Name = "Lions", City = "Detroit", Conf = Conference.NFC, Div = Division.North, ShortName = "DET" },

				// NFC SOUTH
				new Team { Name = "Saints", City = "New Orleans", Conf = Conference.NFC, Div = Division.South, ShortName = "NO" },
				new Team { Name = "Falcons", City = "Atlanta", Conf = Conference.NFC, Div = Division.South, ShortName = "ATL" },
				new Team { Name = "Panthers", City = "Carolina", Conf = Conference.NFC, Div = Division.South, ShortName = "CAR" },
				new Team { Name = "Buccaneers", City = "Tampa Bay", Conf = Conference.NFC, Div = Division.South, ShortName = "TB" },

				// NFC WEST
				new Team { Name = "Rams", City = "Los Angeles", Conf = Conference.NFC, Div = Division.West, ShortName = "LA" },
				new Team { Name = "Seahawks", City = "Seattle", Conf = Conference.NFC, Div = Division.West, ShortName = "SEA" },
				new Team { Name = "49ers", City = "San Francisco", Conf = Conference.NFC, Div = Division.West, ShortName = "SF" },
				new Team { Name = "Cardinals", City = "Arizona", Conf = Conference.NFC, Div = Division.West, ShortName = "ARI" }
			);
		}

		private static void PopulateMatches(NFLContext Nfl)
		{
			if (Nfl.Matches.Any())
			{
				// Database was already seeded
				return;
			}

			Nfl.Matches.AddRange(

				// Season 2018, week 1
				//new Match { Season = 2018, Week = 1, HomeTeamId = 0, HomeScore = 0, AwayTeamId = 0, AwayScore = 0 },
				//new Match { Season = 2018, Week = 1, HomeTeamId = 0, HomeScore = 0, AwayTeamId = 0, AwayScore = 0 },
				//new Match { Season = 2018, Week = 1, HomeTeamId = 0, HomeScore = 0, AwayTeamId = 0, AwayScore = 0 },
				//new Match { Season = 2018, Week = 1, HomeTeamId = 0, HomeScore = 0, AwayTeamId = 0, AwayScore = 0 },
				//new Match { Season = 2018, Week = 1, HomeTeamId = 0, HomeScore = 0, AwayTeamId = 0, AwayScore = 0 },
				//new Match { Season = 2018, Week = 1, HomeTeamId = 0, HomeScore = 0, AwayTeamId = 0, AwayScore = 0 },
				//new Match { Season = 2018, Week = 1, HomeTeamId = 0, HomeScore = 0, AwayTeamId = 0, AwayScore = 0 },
				//new Match { Season = 2018, Week = 1, HomeTeamId = 0, HomeScore = 0, AwayTeamId = 0, AwayScore = 0 },
				//new Match { Season = 2018, Week = 1, HomeTeamId = 0, HomeScore = 0, AwayTeamId = 0, AwayScore = 0 },
				//new Match { Season = 2018, Week = 1, HomeTeamId = 0, HomeScore = 0, AwayTeamId = 0, AwayScore = 0 },
				//new Match { Season = 2018, Week = 1, HomeTeamId = 0, HomeScore = 0, AwayTeamId = 0, AwayScore = 0 },
				//new Match { Season = 2018, Week = 1, HomeTeamId = 0, HomeScore = 0, AwayTeamId = 0, AwayScore = 0 }
			);
		}
	}
}
