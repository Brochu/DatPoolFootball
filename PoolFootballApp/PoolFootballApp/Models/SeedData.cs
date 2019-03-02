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
				new Match { Season = 2018, Week = 1, HomeTeamId = "PHI", HomeScore = 18, AwayTeamId = "ATL", AwayScore = 12, WeekDay = Day.Thu, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "BAL", HomeScore = 47, AwayTeamId = "BUF", AwayScore = 3, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "CLE", HomeScore = 21, AwayTeamId = "PIT", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "IND", HomeScore = 23, AwayTeamId = "CIN", AwayScore = 34, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "MIA", HomeScore = 27, AwayTeamId = "TEN", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "MIN", HomeScore = 24, AwayTeamId = "SF", AwayScore = 16, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "NE", HomeScore = 27, AwayTeamId = "HOU", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "NO", HomeScore = 40, AwayTeamId = "TB", AwayScore = 48, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "NYG", HomeScore = 15, AwayTeamId = "JAX", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "LAC", HomeScore = 28, AwayTeamId = "KC", AwayScore = 38, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:05") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "ARI", HomeScore = 6, AwayTeamId = "WAS", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "CAR", HomeScore = 16, AwayTeamId = "DAL", AwayScore = 8, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "DEN", HomeScore = 27, AwayTeamId = "SEA", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "GB", HomeScore = 24, AwayTeamId = "CHI", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "DET", HomeScore = 17, AwayTeamId = "NYJ", AwayScore = 48, WeekDay = Day.Mon, StartTime = DateTime.Parse("7:10") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "OAK", HomeScore = 13, AwayTeamId = "LA", AwayScore = 33, WeekDay = Day.Mon, StartTime = DateTime.Parse("10:20") },

				// Season 2018, week 2
				new Match { Season = 2018, Week = 2, HomeTeamId = "CIN", HomeScore = 34, AwayTeamId = "BAL", AwayScore = 23, WeekDay = Day.Thu, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "ATL", HomeScore = 31, AwayTeamId = "CAR", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "BUF", HomeScore = 20, AwayTeamId = "LAC", AwayScore = 31, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "GB", HomeScore = 29, AwayTeamId = "MIN", AwayScore = 29, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "NO", HomeScore = 21, AwayTeamId = "CLE", AwayScore = 18, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "NYJ", HomeScore = 12, AwayTeamId = "MIA", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "PIT", HomeScore = 37, AwayTeamId = "KC", AwayScore = 42, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "TB", HomeScore = 27, AwayTeamId = "PHI", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "TEN", HomeScore = 20, AwayTeamId = "HOU", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "WAS", HomeScore = 9, AwayTeamId = "IND", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "LA", HomeScore = 34, AwayTeamId = "ARI", AwayScore = 0, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:05") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "SF", HomeScore = 30, AwayTeamId = "DET", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:05") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "DEN", HomeScore = 20, AwayTeamId = "OAK", AwayScore = 19, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "JAX", HomeScore = 31, AwayTeamId = "NE", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "DAL", HomeScore = 20, AwayTeamId = "NYG", AwayScore = 13, WeekDay = Day.Sun, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "CHI", HomeScore = 24, AwayTeamId = "SEA", AwayScore = 17, WeekDay = Day.Mon, StartTime = DateTime.Parse("8:15") },

				// Season 2018, week 3
				new Match { Season = 2018, Week = 3, HomeTeamId = "CLE", HomeScore = 21, AwayTeamId = "NYJ", AwayScore = 17, WeekDay = Day.Thu, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "ATL", HomeScore = 37, AwayTeamId = "NO", AwayScore = 43, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "BAL", HomeScore = 27, AwayTeamId = "DEN", AwayScore = 14, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "CAR", HomeScore = 31, AwayTeamId = "CIN", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "HOU", HomeScore = 22, AwayTeamId = "NYG", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "JAX", HomeScore = 6, AwayTeamId = "TEN", AwayScore = 9, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "KC", HomeScore = 38, AwayTeamId = "SF", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "MIA", HomeScore = 28, AwayTeamId = "OAK", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "MIN", HomeScore = 6, AwayTeamId = "BUF", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "PHI", HomeScore = 20, AwayTeamId = "IND", AwayScore = 16, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "WAS", HomeScore = 31, AwayTeamId = "GB", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "LA", HomeScore = 35, AwayTeamId = "LAC", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:05") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "ARI", HomeScore = 14, AwayTeamId = "CHI", AwayScore = 16, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "SEA", HomeScore = 24, AwayTeamId = "DAL", AwayScore = 13, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "DET", HomeScore = 26, AwayTeamId = "NE", AwayScore = 10, WeekDay = Day.Sun, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "TB", HomeScore = 27, AwayTeamId = "PIT", AwayScore = 30, WeekDay = Day.Mon, StartTime = DateTime.Parse("8:15") },

				// Season 2018, week 4
				new Match { Season = 2018, Week = 4, HomeTeamId = "LA", HomeScore = 38, AwayTeamId = "MIN", AwayScore = 31, WeekDay = Day.Thu, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "JAX", HomeScore = 31, AwayTeamId = "NYJ", AwayScore = 12, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "NE", HomeScore = 38, AwayTeamId = "MIA", AwayScore = 7, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "TEN", HomeScore = 26, AwayTeamId = "PHI", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "ATL", HomeScore = 36, AwayTeamId = "CIN", AwayScore = 37, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "CHI", HomeScore = 48, AwayTeamId = "TB", AwayScore = 10, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "DAL", HomeScore = 26, AwayTeamId = "DET", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "GB", HomeScore = 22, AwayTeamId = "BUF", AwayScore = 0, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "IND", HomeScore = 34, AwayTeamId = "HOU", AwayScore = 37, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "ARI", HomeScore = 17, AwayTeamId = "SEA", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:05") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "OAK", HomeScore = 45, AwayTeamId = "CLE", AwayScore = 42, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:05") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "LAC", HomeScore = 29, AwayTeamId = "SF", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "NYG", HomeScore = 18, AwayTeamId = "NO", AwayScore = 33, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "PIT", HomeScore = 14, AwayTeamId = "BAL", AwayScore = 26, WeekDay = Day.Sun, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "DEN", HomeScore = 23, AwayTeamId = "KC", AwayScore = 27, WeekDay = Day.Mon, StartTime = DateTime.Parse("8:15") },

				// Season 2018, week 5
				new Match { Season = 2018, Week = 5, HomeTeamId = "NE", HomeScore = 38, AwayTeamId = "IND", AwayScore = 24, WeekDay = Day.Thu, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "BUF", HomeScore = 13, AwayTeamId = "TEN", AwayScore = 12, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "CAR", HomeScore = 33, AwayTeamId = "NYG", AwayScore = 31, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "CIN", HomeScore = 27, AwayTeamId = "MIA", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "CLE", HomeScore = 12, AwayTeamId = "BAL", AwayScore = 9, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "DET", HomeScore = 31, AwayTeamId = "GB", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "KC", HomeScore = 30, AwayTeamId = "JAX", AwayScore = 14, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "NYJ", HomeScore = 34, AwayTeamId = "DEN", AwayScore = 16, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "PIT", HomeScore = 41, AwayTeamId = "ATL", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "LAC", HomeScore = 26, AwayTeamId = "OAK", AwayScore = 10, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:05") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "PHI", HomeScore = 21, AwayTeamId = "MIN", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "SF", HomeScore = 18, AwayTeamId = "ARI", AwayScore = 28, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "SEA", HomeScore = 31, AwayTeamId = "LA", AwayScore = 33, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "HOU", HomeScore = 19, AwayTeamId = "DAL", AwayScore = 16, WeekDay = Day.Sun, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "NO", HomeScore = 43, AwayTeamId = "WAS", AwayScore = 19, WeekDay = Day.Mon, StartTime = DateTime.Parse("8:15") },

				// Season 2018, week 6
				new Match { Season = 2018, Week = 6, HomeTeamId = "NYG", HomeScore = 13, AwayTeamId = "PHI", AwayScore = 34, WeekDay = Day.Thu, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "ATL", HomeScore = 34, AwayTeamId = "TB", AwayScore = 29, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "CIN", HomeScore = 21, AwayTeamId = "PIT", AwayScore = 28, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "CLE", HomeScore = 14, AwayTeamId = "LAC", AwayScore = 38, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "HOU", HomeScore = 20, AwayTeamId = "BUF", AwayScore = 13, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "MIA", HomeScore = 31, AwayTeamId = "CHI", AwayScore = 28, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "MIN", HomeScore = 27, AwayTeamId = "ARI", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "NYJ", HomeScore = 42, AwayTeamId = "IND", AwayScore = 34, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "OAK", HomeScore = 3, AwayTeamId = "SEA", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "WAS", HomeScore = 23, AwayTeamId = "CAR", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "DEN", HomeScore = 20, AwayTeamId = "LA", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:05") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "DAL", HomeScore = 40, AwayTeamId = "JAX", AwayScore = 7, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "TEN", HomeScore = 0, AwayTeamId = "BAL", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "NE", HomeScore = 43, AwayTeamId = "KC", AwayScore = 40, WeekDay = Day.Sun, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "GB", HomeScore = 33, AwayTeamId = "SF", AwayScore = 30, WeekDay = Day.Mon, StartTime = DateTime.Parse("8:15") },

				// Season 2018, week 7
				new Match { Season = 2018, Week = 7, HomeTeamId = "ARI", HomeScore = 10, AwayTeamId = "DEN", AwayScore = 45, WeekDay = Day.Thu, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "LAC", HomeScore = 20, AwayTeamId = "TEN", AwayScore = 19, WeekDay = Day.Sun, StartTime = DateTime.Parse("9:30") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "CHI", HomeScore = 31, AwayTeamId = "NE", AwayScore = 38, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "IND", HomeScore = 37, AwayTeamId = "BUF", AwayScore = 5, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "JAX", HomeScore = 7, AwayTeamId = "HOU", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "MIA", HomeScore = 21, AwayTeamId = "DET", AwayScore = 32, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "NYJ", HomeScore = 17, AwayTeamId = "MIN", AwayScore = 37, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "PHI", HomeScore = 17, AwayTeamId = "CAR", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "TB", HomeScore = 26, AwayTeamId = "CLE", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "BAL", HomeScore = 23, AwayTeamId = "NO", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:05") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "WAS", HomeScore = 20, AwayTeamId = "DAL", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "SF", HomeScore = 10, AwayTeamId = "LA", AwayScore = 39, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "KC", HomeScore = 45, AwayTeamId = "CIN", AwayScore = 10, WeekDay = Day.Sun, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "ATL", HomeScore = 23, AwayTeamId = "NYG", AwayScore = 20, WeekDay = Day.Mon, StartTime = DateTime.Parse("8:15") },

				// Season 2018, week 8
				new Match { Season = 2018, Week = 8, HomeTeamId = "HOU", HomeScore = 42, AwayTeamId = "MIA", AwayScore = 23, WeekDay = Day.Thu, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "JAX", HomeScore = 18, AwayTeamId = "PHI", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("9:30") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "CAR", HomeScore = 36, AwayTeamId = "BAL", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "CHI", HomeScore = 24, AwayTeamId = "NYJ", AwayScore = 10, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "CIN", HomeScore = 37, AwayTeamId = "TB", AwayScore = 34, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "DET", HomeScore = 14, AwayTeamId = "SEA", AwayScore = 28, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "KC", HomeScore = 30, AwayTeamId = "DEN", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "NYG", HomeScore = 13, AwayTeamId = "WAS", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "PIT", HomeScore = 33, AwayTeamId = "CLE", AwayScore = 18, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "OAK", HomeScore = 28, AwayTeamId = "IND", AwayScore = 42, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:05") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "ARI", HomeScore = 18, AwayTeamId = "SF", AwayScore = 15, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "LA", HomeScore = 29, AwayTeamId = "GB", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "MIN", HomeScore = 20, AwayTeamId = "NO", AwayScore = 30, WeekDay = Day.Sun, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "BUF", HomeScore = 6, AwayTeamId = "NE", AwayScore = 25, WeekDay = Day.Mon, StartTime = DateTime.Parse("8:15") },

				// Season 2018, week 9
				new Match { Season = 2018, Week = 9, HomeTeamId = "SF", HomeScore = 34, AwayTeamId = "OAK", AwayScore = 3, WeekDay = Day.Thu, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "BUF", HomeScore = 9, AwayTeamId = "CHI", AwayScore = 41, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "CAR", HomeScore = 42, AwayTeamId = "TB", AwayScore = 28, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "CLE", HomeScore = 21, AwayTeamId = "KC", AwayScore = 37, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "MIA", HomeScore = 13, AwayTeamId = "NYJ", AwayScore = 6, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "BAL", HomeScore = 16, AwayTeamId = "PIT", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "MIN", HomeScore = 24, AwayTeamId = "DET", AwayScore = 9, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "WAS", HomeScore = 14, AwayTeamId = "ATL", AwayScore = 38, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "DEN", HomeScore = 17, AwayTeamId = "HOU", AwayScore = 19, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:05") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "SEA", HomeScore = 17, AwayTeamId = "LAC", AwayScore = 25, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:05") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "NO", HomeScore = 45, AwayTeamId = "LA", AwayScore = 35, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "NE", HomeScore = 31, AwayTeamId = "GB", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "DAL", HomeScore = 14, AwayTeamId = "TEN", AwayScore = 28, WeekDay = Day.Mon, StartTime = DateTime.Parse("8:15") },

				// Season 2018, week 10
				new Match { Season = 2018, Week = 10, HomeTeamId = "PIT", HomeScore = 52, AwayTeamId = "CAR", AwayScore = 21, WeekDay = Day.Thu, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "CIN", HomeScore = 14, AwayTeamId = "NO", AwayScore = 51, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "CLE", HomeScore = 28, AwayTeamId = "ATL", AwayScore = 16, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "IND", HomeScore = 29, AwayTeamId = "JAX", AwayScore = 26, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "CHI", HomeScore = 34, AwayTeamId = "DET", AwayScore = 22, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "KC", HomeScore = 26, AwayTeamId = "ARI", AwayScore = 14, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "NYJ", HomeScore = 10, AwayTeamId = "BUF", AwayScore = 41, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "TB", HomeScore = 3, AwayTeamId = "WAS", AwayScore = 16, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "TEN", HomeScore = 34, AwayTeamId = "NE", AwayScore = 10, WeekDay = Day.Sun, StartTime = DateTime.Parse("1:00") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "OAK", HomeScore = 6, AwayTeamId = "LAC", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:05") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "GB", HomeScore = 31, AwayTeamId = "MIA", AwayScore = 12, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "LA", HomeScore = 36, AwayTeamId = "SEA", AwayScore = 31, WeekDay = Day.Sun, StartTime = DateTime.Parse("4:25") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "PHI", HomeScore = 20, AwayTeamId = "DAL", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("8:20") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "SF", HomeScore = 23, AwayTeamId = "NYG", AwayScore = 27, WeekDay = Day.Mon, StartTime = DateTime.Parse("8:15") }
			);
		}
	}
}
