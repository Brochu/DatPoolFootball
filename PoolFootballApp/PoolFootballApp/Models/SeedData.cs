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
				new Match { Season = 2018, Week = 1, HomeTeamId = "PHI", HomeScore = 18, AwayTeamId = "ATL", AwayScore = 12, WeekDay = Day.Thu, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "BAL", HomeScore = 47, AwayTeamId = "BUF", AwayScore = 3, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "CLE", HomeScore = 21, AwayTeamId = "PIT", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "IND", HomeScore = 23, AwayTeamId = "CIN", AwayScore = 34, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "MIA", HomeScore = 27, AwayTeamId = "TEN", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "MIN", HomeScore = 24, AwayTeamId = "SF", AwayScore = 16, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "NE", HomeScore = 27, AwayTeamId = "HOU", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "NO", HomeScore = 40, AwayTeamId = "TB", AwayScore = 48, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "NYG", HomeScore = 15, AwayTeamId = "JAX", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "LAC", HomeScore = 28, AwayTeamId = "KC", AwayScore = 38, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "ARI", HomeScore = 6, AwayTeamId = "WAS", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "CAR", HomeScore = 16, AwayTeamId = "DAL", AwayScore = 8, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "DEN", HomeScore = 27, AwayTeamId = "SEA", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "GB", HomeScore = 24, AwayTeamId = "CHI", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "DET", HomeScore = 17, AwayTeamId = "NYJ", AwayScore = 48, WeekDay = Day.Mon, StartTime = DateTime.Parse("19:10") },
				new Match { Season = 2018, Week = 1, HomeTeamId = "OAK", HomeScore = 13, AwayTeamId = "LA", AwayScore = 33, WeekDay = Day.Mon, StartTime = DateTime.Parse("22:20") },

				new Match { Season = 2018, Week = 2, HomeTeamId = "CIN", HomeScore = 34, AwayTeamId = "BAL", AwayScore = 23, WeekDay = Day.Thu, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "ATL", HomeScore = 31, AwayTeamId = "CAR", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "BUF", HomeScore = 20, AwayTeamId = "LAC", AwayScore = 31, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "GB", HomeScore = 29, AwayTeamId = "MIN", AwayScore = 29, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "NO", HomeScore = 21, AwayTeamId = "CLE", AwayScore = 18, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "NYJ", HomeScore = 12, AwayTeamId = "MIA", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "PIT", HomeScore = 37, AwayTeamId = "KC", AwayScore = 42, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "TB", HomeScore = 27, AwayTeamId = "PHI", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "TEN", HomeScore = 20, AwayTeamId = "HOU", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "WAS", HomeScore = 9, AwayTeamId = "IND", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "LA", HomeScore = 34, AwayTeamId = "ARI", AwayScore = 0, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "SF", HomeScore = 30, AwayTeamId = "DET", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "DEN", HomeScore = 20, AwayTeamId = "OAK", AwayScore = 19, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "JAX", HomeScore = 31, AwayTeamId = "NE", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "DAL", HomeScore = 20, AwayTeamId = "NYG", AwayScore = 13, WeekDay = Day.Sun, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 2, HomeTeamId = "CHI", HomeScore = 24, AwayTeamId = "SEA", AwayScore = 17, WeekDay = Day.Mon, StartTime = DateTime.Parse("20:15") },

				new Match { Season = 2018, Week = 3, HomeTeamId = "CLE", HomeScore = 21, AwayTeamId = "NYJ", AwayScore = 17, WeekDay = Day.Thu, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "ATL", HomeScore = 37, AwayTeamId = "NO", AwayScore = 43, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "BAL", HomeScore = 27, AwayTeamId = "DEN", AwayScore = 13, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "CAR", HomeScore = 31, AwayTeamId = "CIN", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "HOU", HomeScore = 22, AwayTeamId = "NYG", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "JAX", HomeScore = 6, AwayTeamId = "TEN", AwayScore = 9, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "KC", HomeScore = 38, AwayTeamId = "SF", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "MIA", HomeScore = 28, AwayTeamId = "OAK", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "MIN", HomeScore = 6, AwayTeamId = "BUF", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "PHI", HomeScore = 20, AwayTeamId = "IND", AwayScore = 16, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "WAS", HomeScore = 31, AwayTeamId = "GB", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "LA", HomeScore = 35, AwayTeamId = "LAC", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "ARI", HomeScore = 13, AwayTeamId = "CHI", AwayScore = 16, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "SEA", HomeScore = 24, AwayTeamId = "DAL", AwayScore = 13, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "DET", HomeScore = 26, AwayTeamId = "NE", AwayScore = 10, WeekDay = Day.Sun, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 3, HomeTeamId = "TB", HomeScore = 27, AwayTeamId = "PIT", AwayScore = 30, WeekDay = Day.Mon, StartTime = DateTime.Parse("20:15") },

				new Match { Season = 2018, Week = 4, HomeTeamId = "LA", HomeScore = 38, AwayTeamId = "MIN", AwayScore = 31, WeekDay = Day.Thu, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "JAX", HomeScore = 31, AwayTeamId = "NYJ", AwayScore = 12, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "NE", HomeScore = 38, AwayTeamId = "MIA", AwayScore = 7, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "TEN", HomeScore = 26, AwayTeamId = "PHI", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "ATL", HomeScore = 36, AwayTeamId = "CIN", AwayScore = 37, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "CHI", HomeScore = 48, AwayTeamId = "TB", AwayScore = 10, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "DAL", HomeScore = 26, AwayTeamId = "DET", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "GB", HomeScore = 22, AwayTeamId = "BUF", AwayScore = 0, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "IND", HomeScore = 34, AwayTeamId = "HOU", AwayScore = 37, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "ARI", HomeScore = 17, AwayTeamId = "SEA", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "OAK", HomeScore = 45, AwayTeamId = "CLE", AwayScore = 42, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "LAC", HomeScore = 29, AwayTeamId = "SF", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "NYG", HomeScore = 18, AwayTeamId = "NO", AwayScore = 33, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "PIT", HomeScore = 13, AwayTeamId = "BAL", AwayScore = 26, WeekDay = Day.Sun, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 4, HomeTeamId = "DEN", HomeScore = 23, AwayTeamId = "KC", AwayScore = 27, WeekDay = Day.Mon, StartTime = DateTime.Parse("20:15") },

				new Match { Season = 2018, Week = 5, HomeTeamId = "NE", HomeScore = 38, AwayTeamId = "IND", AwayScore = 24, WeekDay = Day.Thu, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "BUF", HomeScore = 13, AwayTeamId = "TEN", AwayScore = 12, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "CAR", HomeScore = 33, AwayTeamId = "NYG", AwayScore = 31, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "CIN", HomeScore = 27, AwayTeamId = "MIA", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "CLE", HomeScore = 12, AwayTeamId = "BAL", AwayScore = 9, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "DET", HomeScore = 31, AwayTeamId = "GB", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "KC", HomeScore = 30, AwayTeamId = "JAX", AwayScore = 13, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "NYJ", HomeScore = 34, AwayTeamId = "DEN", AwayScore = 16, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "PIT", HomeScore = 41, AwayTeamId = "ATL", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "LAC", HomeScore = 26, AwayTeamId = "OAK", AwayScore = 10, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "PHI", HomeScore = 21, AwayTeamId = "MIN", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "SF", HomeScore = 18, AwayTeamId = "ARI", AwayScore = 28, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "SEA", HomeScore = 31, AwayTeamId = "LA", AwayScore = 33, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "HOU", HomeScore = 19, AwayTeamId = "DAL", AwayScore = 16, WeekDay = Day.Sun, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 5, HomeTeamId = "NO", HomeScore = 43, AwayTeamId = "WAS", AwayScore = 19, WeekDay = Day.Mon, StartTime = DateTime.Parse("20:15") },

				new Match { Season = 2018, Week = 6, HomeTeamId = "NYG", HomeScore = 13, AwayTeamId = "PHI", AwayScore = 34, WeekDay = Day.Thu, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "ATL", HomeScore = 34, AwayTeamId = "TB", AwayScore = 29, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "CIN", HomeScore = 21, AwayTeamId = "PIT", AwayScore = 28, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "CLE", HomeScore = 13, AwayTeamId = "LAC", AwayScore = 38, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "HOU", HomeScore = 20, AwayTeamId = "BUF", AwayScore = 13, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "MIA", HomeScore = 31, AwayTeamId = "CHI", AwayScore = 28, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "MIN", HomeScore = 27, AwayTeamId = "ARI", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "NYJ", HomeScore = 42, AwayTeamId = "IND", AwayScore = 34, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "OAK", HomeScore = 3, AwayTeamId = "SEA", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "WAS", HomeScore = 23, AwayTeamId = "CAR", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "DEN", HomeScore = 20, AwayTeamId = "LA", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "DAL", HomeScore = 40, AwayTeamId = "JAX", AwayScore = 7, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "TEN", HomeScore = 0, AwayTeamId = "BAL", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "NE", HomeScore = 43, AwayTeamId = "KC", AwayScore = 40, WeekDay = Day.Sun, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 6, HomeTeamId = "GB", HomeScore = 33, AwayTeamId = "SF", AwayScore = 30, WeekDay = Day.Mon, StartTime = DateTime.Parse("20:15") },

				new Match { Season = 2018, Week = 7, HomeTeamId = "ARI", HomeScore = 10, AwayTeamId = "DEN", AwayScore = 45, WeekDay = Day.Thu, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "LAC", HomeScore = 20, AwayTeamId = "TEN", AwayScore = 19, WeekDay = Day.Sun, StartTime = DateTime.Parse("21:30") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "CHI", HomeScore = 31, AwayTeamId = "NE", AwayScore = 38, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "IND", HomeScore = 37, AwayTeamId = "BUF", AwayScore = 5, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "JAX", HomeScore = 7, AwayTeamId = "HOU", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "MIA", HomeScore = 21, AwayTeamId = "DET", AwayScore = 32, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "NYJ", HomeScore = 17, AwayTeamId = "MIN", AwayScore = 37, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "PHI", HomeScore = 17, AwayTeamId = "CAR", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "TB", HomeScore = 26, AwayTeamId = "CLE", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "BAL", HomeScore = 23, AwayTeamId = "NO", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "WAS", HomeScore = 20, AwayTeamId = "DAL", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "SF", HomeScore = 10, AwayTeamId = "LA", AwayScore = 39, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "KC", HomeScore = 45, AwayTeamId = "CIN", AwayScore = 10, WeekDay = Day.Sun, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 7, HomeTeamId = "ATL", HomeScore = 23, AwayTeamId = "NYG", AwayScore = 20, WeekDay = Day.Mon, StartTime = DateTime.Parse("20:15") },

				new Match { Season = 2018, Week = 8, HomeTeamId = "HOU", HomeScore = 42, AwayTeamId = "MIA", AwayScore = 23, WeekDay = Day.Thu, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "JAX", HomeScore = 18, AwayTeamId = "PHI", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("21:30") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "CAR", HomeScore = 36, AwayTeamId = "BAL", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "CHI", HomeScore = 24, AwayTeamId = "NYJ", AwayScore = 10, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "CIN", HomeScore = 37, AwayTeamId = "TB", AwayScore = 34, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "DET", HomeScore = 13, AwayTeamId = "SEA", AwayScore = 28, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "KC", HomeScore = 30, AwayTeamId = "DEN", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "NYG", HomeScore = 13, AwayTeamId = "WAS", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "PIT", HomeScore = 33, AwayTeamId = "CLE", AwayScore = 18, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "OAK", HomeScore = 28, AwayTeamId = "IND", AwayScore = 42, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "ARI", HomeScore = 18, AwayTeamId = "SF", AwayScore = 15, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "LA", HomeScore = 29, AwayTeamId = "GB", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "MIN", HomeScore = 20, AwayTeamId = "NO", AwayScore = 30, WeekDay = Day.Sun, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 8, HomeTeamId = "BUF", HomeScore = 6, AwayTeamId = "NE", AwayScore = 25, WeekDay = Day.Mon, StartTime = DateTime.Parse("20:15") },

				new Match { Season = 2018, Week = 9, HomeTeamId = "SF", HomeScore = 34, AwayTeamId = "OAK", AwayScore = 3, WeekDay = Day.Thu, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "BUF", HomeScore = 9, AwayTeamId = "CHI", AwayScore = 41, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "CAR", HomeScore = 42, AwayTeamId = "TB", AwayScore = 28, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "CLE", HomeScore = 21, AwayTeamId = "KC", AwayScore = 37, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "MIA", HomeScore = 13, AwayTeamId = "NYJ", AwayScore = 6, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "BAL", HomeScore = 16, AwayTeamId = "PIT", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "MIN", HomeScore = 24, AwayTeamId = "DET", AwayScore = 9, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "WAS", HomeScore = 13, AwayTeamId = "ATL", AwayScore = 38, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "DEN", HomeScore = 17, AwayTeamId = "HOU", AwayScore = 19, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "SEA", HomeScore = 17, AwayTeamId = "LAC", AwayScore = 25, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "NO", HomeScore = 45, AwayTeamId = "LA", AwayScore = 35, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "NE", HomeScore = 31, AwayTeamId = "GB", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 9, HomeTeamId = "DAL", HomeScore = 13, AwayTeamId = "TEN", AwayScore = 28, WeekDay = Day.Mon, StartTime = DateTime.Parse("20:15") },

				new Match { Season = 2018, Week = 10, HomeTeamId = "PIT", HomeScore = 52, AwayTeamId = "CAR", AwayScore = 21, WeekDay = Day.Thu, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "CIN", HomeScore = 13, AwayTeamId = "NO", AwayScore = 51, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "CLE", HomeScore = 28, AwayTeamId = "ATL", AwayScore = 16, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "IND", HomeScore = 29, AwayTeamId = "JAX", AwayScore = 26, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "CHI", HomeScore = 34, AwayTeamId = "DET", AwayScore = 22, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "KC", HomeScore = 26, AwayTeamId = "ARI", AwayScore = 13, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "NYJ", HomeScore = 10, AwayTeamId = "BUF", AwayScore = 41, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "TB", HomeScore = 3, AwayTeamId = "WAS", AwayScore = 16, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "TEN", HomeScore = 34, AwayTeamId = "NE", AwayScore = 10, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "OAK", HomeScore = 6, AwayTeamId = "LAC", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "GB", HomeScore = 31, AwayTeamId = "MIA", AwayScore = 12, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "LA", HomeScore = 36, AwayTeamId = "SEA", AwayScore = 31, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "PHI", HomeScore = 20, AwayTeamId = "DAL", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 10, HomeTeamId = "SF", HomeScore = 23, AwayTeamId = "NYG", AwayScore = 27, WeekDay = Day.Mon, StartTime = DateTime.Parse("20:15") },

				new Match { Season = 2018, Week = 11, HomeTeamId = "SEA", HomeScore = 27, AwayTeamId = "GB", AwayScore = 24, WeekDay = Day.Thu, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 11, HomeTeamId = "BAL", HomeScore = 24, AwayTeamId = "CIN", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 11, HomeTeamId = "DET", HomeScore = 20, AwayTeamId = "CAR", AwayScore = 19, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 11, HomeTeamId = "IND", HomeScore = 38, AwayTeamId = "TEN", AwayScore = 10, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 11, HomeTeamId = "ATL", HomeScore = 19, AwayTeamId = "DAL", AwayScore = 22, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 11, HomeTeamId = "NYG", HomeScore = 38, AwayTeamId = "TB", AwayScore = 35, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 11, HomeTeamId = "WAS", HomeScore = 21, AwayTeamId = "HOU", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 11, HomeTeamId = "JAX", HomeScore = 16, AwayTeamId = "PIT", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 11, HomeTeamId = "ARI", HomeScore = 21, AwayTeamId = "OAK", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 11, HomeTeamId = "LAC", HomeScore = 22, AwayTeamId = "DEN", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 11, HomeTeamId = "NO", HomeScore = 48, AwayTeamId = "PHI", AwayScore = 7, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 11, HomeTeamId = "CHI", HomeScore = 25, AwayTeamId = "MIN", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 11, HomeTeamId = "LA", HomeScore = 54, AwayTeamId = "KC", AwayScore = 51, WeekDay = Day.Mon, StartTime = DateTime.Parse("20:15") },

				new Match { Season = 2018, Week = 12, HomeTeamId = "DET", HomeScore = 16, AwayTeamId = "CHI", AwayScore = 23, WeekDay = Day.Thu, StartTime = DateTime.Parse("00:30") },
				new Match { Season = 2018, Week = 12, HomeTeamId = "DAL", HomeScore = 31, AwayTeamId = "WAS", AwayScore = 23, WeekDay = Day.Thu, StartTime = DateTime.Parse("16:30") },
				new Match { Season = 2018, Week = 12, HomeTeamId = "NO", HomeScore = 31, AwayTeamId = "ATL", AwayScore = 17, WeekDay = Day.Thu, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 12, HomeTeamId = "CIN", HomeScore = 20, AwayTeamId = "CLE", AwayScore = 35, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 12, HomeTeamId = "CAR", HomeScore = 27, AwayTeamId = "SEA", AwayScore = 30, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 12, HomeTeamId = "BUF", HomeScore = 24, AwayTeamId = "JAX", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 12, HomeTeamId = "BAL", HomeScore = 34, AwayTeamId = "OAK", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 12, HomeTeamId = "NYJ", HomeScore = 13, AwayTeamId = "NE", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 12, HomeTeamId = "PHI", HomeScore = 25, AwayTeamId = "NYG", AwayScore = 22, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 12, HomeTeamId = "TB", HomeScore = 27, AwayTeamId = "SF", AwayScore = 9, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 12, HomeTeamId = "LAC", HomeScore = 45, AwayTeamId = "ARI", AwayScore = 10, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 12, HomeTeamId = "IND", HomeScore = 27, AwayTeamId = "MIA", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 12, HomeTeamId = "DEN", HomeScore = 24, AwayTeamId = "PIT", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 12, HomeTeamId = "MIN", HomeScore = 24, AwayTeamId = "GB", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 12, HomeTeamId = "HOU", HomeScore = 34, AwayTeamId = "TEN", AwayScore = 17, WeekDay = Day.Mon, StartTime = DateTime.Parse("20:15") },

				new Match { Season = 2018, Week = 13, HomeTeamId = "DAL", HomeScore = 13, AwayTeamId = "NO", AwayScore = 10, WeekDay = Day.Thu, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "ATL", HomeScore = 16, AwayTeamId = "BAL", AwayScore = 26, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "CIN", HomeScore = 10, AwayTeamId = "DEN", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "DET", HomeScore = 16, AwayTeamId = "LA", AwayScore = 30, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "GB", HomeScore = 17, AwayTeamId = "ARI", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "HOU", HomeScore = 29, AwayTeamId = "CLE", AwayScore = 13, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "JAX", HomeScore = 6, AwayTeamId = "IND", AwayScore = 0, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "MIA", HomeScore = 21, AwayTeamId = "BUF", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "NYG", HomeScore = 30, AwayTeamId = "CHI", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "TB", HomeScore = 24, AwayTeamId = "CAR", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "OAK", HomeScore = 33, AwayTeamId = "KC", AwayScore = 40, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "TEN", HomeScore = 26, AwayTeamId = "NYJ", AwayScore = 22, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "NE", HomeScore = 24, AwayTeamId = "MIN", AwayScore = 10, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "SEA", HomeScore = 43, AwayTeamId = "SF", AwayScore = 16, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "PIT", HomeScore = 30, AwayTeamId = "LAC", AwayScore = 33, WeekDay = Day.Sun, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "PHI", HomeScore = 28, AwayTeamId = "WAS", AwayScore = 13, WeekDay = Day.Mon, StartTime = DateTime.Parse("20:15") },

				new Match { Season = 2018, Week = 13, HomeTeamId = "TEN", HomeScore = 30, AwayTeamId = "JAX", AwayScore = 9, WeekDay = Day.Thu, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "BUF", HomeScore = 23, AwayTeamId = "NYJ", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "CLE", HomeScore = 26, AwayTeamId = "CAR", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "GB", HomeScore = 34, AwayTeamId = "ATL", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "HOU", HomeScore = 21, AwayTeamId = "IND", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "KC", HomeScore = 27, AwayTeamId = "BAL", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "MIA", HomeScore = 34, AwayTeamId = "NE", AwayScore = 33, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "TB", HomeScore = 13, AwayTeamId = "NO", AwayScore = 28, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "WAS", HomeScore = 16, AwayTeamId = "NYG", AwayScore = 40, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "LAC", HomeScore = 26, AwayTeamId = "CIN", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "SF", HomeScore = 20, AwayTeamId = "DEN", AwayScore = 13, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "ARI", HomeScore = 3, AwayTeamId = "DET", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "DAL", HomeScore = 29, AwayTeamId = "PHI", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "OAK", HomeScore = 24, AwayTeamId = "PIT", AwayScore = 21, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "CHI", HomeScore = 15, AwayTeamId = "LA", AwayScore = 6, WeekDay = Day.Sun, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 13, HomeTeamId = "SEA", HomeScore = 21, AwayTeamId = "MIN", AwayScore = 7, WeekDay = Day.Mon, StartTime = DateTime.Parse("20:15") },

				new Match { Season = 2018, Week = 15, HomeTeamId = "KC", HomeScore = 28, AwayTeamId = "LAC", AwayScore = 29, WeekDay = Day.Thu, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 15, HomeTeamId = "NYJ", HomeScore = 22, AwayTeamId = "HOU", AwayScore = 29, WeekDay = Day.Sat, StartTime = DateTime.Parse("16:30") },
				new Match { Season = 2018, Week = 15, HomeTeamId = "DEN", HomeScore = 16, AwayTeamId = "CLE", AwayScore = 17, WeekDay = Day.Sat, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 15, HomeTeamId = "CHI", HomeScore = 24, AwayTeamId = "GB", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 15, HomeTeamId = "BUF", HomeScore = 13, AwayTeamId = "DET", AwayScore = 13, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 15, HomeTeamId = "BAL", HomeScore = 20, AwayTeamId = "TB", AwayScore = 12, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 15, HomeTeamId = "ATL", HomeScore = 40, AwayTeamId = "ARI", AwayScore = 13, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 15, HomeTeamId = "CIN", HomeScore = 30, AwayTeamId = "OAK", AwayScore = 16, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 15, HomeTeamId = "IND", HomeScore = 23, AwayTeamId = "DAL", AwayScore = 0, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 15, HomeTeamId = "JAX", HomeScore = 13, AwayTeamId = "WAS", AwayScore = 16, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 15, HomeTeamId = "MIN", HomeScore = 41, AwayTeamId = "MIA", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 15, HomeTeamId = "NYG", HomeScore = 0, AwayTeamId = "TEN", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 15, HomeTeamId = "SF", HomeScore = 26, AwayTeamId = "SEA", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 15, HomeTeamId = "PIT", HomeScore = 17, AwayTeamId = "NE", AwayScore = 10, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 15, HomeTeamId = "LA", HomeScore = 23, AwayTeamId = "PHI", AwayScore = 30, WeekDay = Day.Sun, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 15, HomeTeamId = "CAR", HomeScore = 9, AwayTeamId = "NO", AwayScore = 12, WeekDay = Day.Mon, StartTime = DateTime.Parse("20:15") },

				new Match { Season = 2018, Week = 16, HomeTeamId = "TEN", HomeScore = 25, AwayTeamId = "WAS", AwayScore = 16, WeekDay = Day.Sat, StartTime = DateTime.Parse("16:30") },
				new Match { Season = 2018, Week = 16, HomeTeamId = "LAC", HomeScore = 10, AwayTeamId = "BAL", AwayScore = 22, WeekDay = Day.Sat, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 16, HomeTeamId = "CLE", HomeScore = 26, AwayTeamId = "CIN", AwayScore = 18, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 16, HomeTeamId = "DAL", HomeScore = 27, AwayTeamId = "TB", AwayScore = 20, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 16, HomeTeamId = "DET", HomeScore = 9, AwayTeamId = "MIN", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 16, HomeTeamId = "NE", HomeScore = 24, AwayTeamId = "BUF", AwayScore = 12, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 16, HomeTeamId = "NYJ", HomeScore = 38, AwayTeamId = "GB", AwayScore = 44, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 16, HomeTeamId = "PHI", HomeScore = 32, AwayTeamId = "HOU", AwayScore = 30, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 16, HomeTeamId = "CAR", HomeScore = 10, AwayTeamId = "ATL", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 16, HomeTeamId = "IND", HomeScore = 28, AwayTeamId = "NYG", AwayScore = 27, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 16, HomeTeamId = "MIA", HomeScore = 7, AwayTeamId = "JAX", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 16, HomeTeamId = "ARI", HomeScore = 9, AwayTeamId = "LA", AwayScore = 31, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 16, HomeTeamId = "SF", HomeScore = 9, AwayTeamId = "CHI", AwayScore = 13, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:05") },
				new Match { Season = 2018, Week = 16, HomeTeamId = "NO", HomeScore = 31, AwayTeamId = "PIT", AwayScore = 28, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 16, HomeTeamId = "SEA", HomeScore = 38, AwayTeamId = "KC", AwayScore = 31, WeekDay = Day.Sun, StartTime = DateTime.Parse("20:20") },
				new Match { Season = 2018, Week = 16, HomeTeamId = "OAK", HomeScore = 27, AwayTeamId = "DEN", AwayScore = 13, WeekDay = Day.Mon, StartTime = DateTime.Parse("20:15") },

				new Match { Season = 2018, Week = 17, HomeTeamId = "GB", HomeScore = 0, AwayTeamId = "DET", AwayScore = 31, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 17, HomeTeamId = "HOU", HomeScore = 20, AwayTeamId = "JAX", AwayScore = 3, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 17, HomeTeamId = "NE", HomeScore = 38, AwayTeamId = "NYJ", AwayScore = 3, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 17, HomeTeamId = "NO", HomeScore = 13, AwayTeamId = "CAR", AwayScore = 33, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 17, HomeTeamId = "NYG", HomeScore = 35, AwayTeamId = "DAL", AwayScore = 36, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 17, HomeTeamId = "TB", HomeScore = 32, AwayTeamId = "ATL", AwayScore = 34, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 17, HomeTeamId = "BUF", HomeScore = 42, AwayTeamId = "MIA", AwayScore = 17, WeekDay = Day.Sun, StartTime = DateTime.Parse("13:00") },
				new Match { Season = 2018, Week = 17, HomeTeamId = "BAL", HomeScore = 26, AwayTeamId = "CLE", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 17, HomeTeamId = "SEA", HomeScore = 27, AwayTeamId = "ARI", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 17, HomeTeamId = "KC", HomeScore = 35, AwayTeamId = "OAK", AwayScore = 3, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 17, HomeTeamId = "MIN", HomeScore = 10, AwayTeamId = "CHI", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 17, HomeTeamId = "PIT", HomeScore = 16, AwayTeamId = "CIN", AwayScore = 13, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 17, HomeTeamId = "WAS", HomeScore = 0, AwayTeamId = "PHI", AwayScore = 24, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 17, HomeTeamId = "DEN", HomeScore = 9, AwayTeamId = "LAC", AwayScore = 23, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 17, HomeTeamId = "LA", HomeScore = 48, AwayTeamId = "SF", AwayScore = 32, WeekDay = Day.Sun, StartTime = DateTime.Parse("16:25") },
				new Match { Season = 2018, Week = 17, HomeTeamId = "TEN", HomeScore = 17, AwayTeamId = "IND", AwayScore = 33, WeekDay = Day.Sun, StartTime = DateTime.Parse("20:20") }
			);
		}
	}
}
