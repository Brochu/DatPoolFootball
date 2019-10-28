using System;
using System.Collections.Generic;
using System.Drawing;

namespace WeekPicker
{
	public static class NFLTeamDB
	{
		private static Dictionary<string, string> lookup = new Dictionary<string, string>()
		{
			{ "ARI", "Arizona" },
			{ "ATL", "Atlanta" },
			{ "BAL", "Baltimore" },
			{ "BUF", "Buffalo" },
			{ "CAR", "Carolina" },
			{ "CHI", "Chicago" },
			{ "CIN", "Cincinnati" },
			{ "CLE", "Cleveland" },
			{ "DAL", "Dallas" },
			{ "DEN", "Denver" },
			{ "DET", "Detroit" },
			{ "GB", "Green Bay" },
			{ "HOU", "Houston" },
			{ "IND", "Indianapolis" },
			{ "JAX", "Jacksonville" },
			{ "KC", "Kansas City" },
			{ "LA", "Los Angeles" },
			{ "LAC", "Los Angeles" },
			{ "MIA", "Miami" },
			{ "MIN", "Minnesota" },
			{ "NE", "New England" },
			{ "NO", "New Orleans" },
			{ "NYG", "New York" },
			{ "NYJ", "New York" },
			{ "OAK", "Oakland" },
			{ "PHI", "Philadelphia" },
			{ "PIT", "Pittsburgh" },
			{ "SEA", "Seattle" },
			{ "SF", "San Francisco" },
			{ "TB", "Tampa Bay" },
			{ "TEN", "Tennessee" },
			{ "WAS", "Washington" }
		};

		private static Dictionary<string, Bitmap> logoLookup = new Dictionary<string, Bitmap>()
		{
			{ "ARI", Properties.Resources.ARI },
			{ "ATL", Properties.Resources.ATL },
			{ "BAL", Properties.Resources.BAL },
			{ "BUF", Properties.Resources.BUF },
			{ "CAR", Properties.Resources.CAR },
			{ "CHI", Properties.Resources.CHI },
			{ "CIN", Properties.Resources.CIN },
			{ "CLE", Properties.Resources.CLE },
			{ "DAL", Properties.Resources.DAL },
			{ "DEN", Properties.Resources.DEN },
			{ "DET", Properties.Resources.DET },
			{ "GB", Properties.Resources.GB },
			{ "HOU", Properties.Resources.HOU },
			{ "IND", Properties.Resources.IND },
			{ "JAX", Properties.Resources.JAX },
			{ "KC", Properties.Resources.KC },
			{ "LA", Properties.Resources.LA },
			{ "LAC", Properties.Resources.LAC },
			{ "MIA", Properties.Resources.MIA },
			{ "MIN", Properties.Resources.MIN },
			{ "NE", Properties.Resources.NE },
			{ "NO", Properties.Resources.NO },
			{ "NYG", Properties.Resources.NYG },
			{ "NYJ", Properties.Resources.NYJ },
			{ "OAK", Properties.Resources.OAK },
			{ "PHI", Properties.Resources.PHI },
			{ "PIT", Properties.Resources.PIT },
			{ "SEA", Properties.Resources.SEA },
			{ "SF", Properties.Resources.SF },
			{ "TB", Properties.Resources.TB },
			{ "TEN", Properties.Resources.TEN },
			{ "WAS", Properties.Resources.WAS }
		};

		public static string GetFullname(string shortname)
		{
			if (!lookup.TryGetValue(shortname, out string fullname))
			{
				Console.WriteLine($"Could not get full name for short name {shortname}");
				return "-NOT-FOUND-";
			}

			return fullname;
		}

		public static Bitmap GetLogo(string shortname)
		{
			if (!logoLookup.TryGetValue(shortname, out Bitmap logo))
			{
				Console.WriteLine($"Could not get logo for short name {shortname}");
				return null;
			}

			return logo;
		}
	}
}
