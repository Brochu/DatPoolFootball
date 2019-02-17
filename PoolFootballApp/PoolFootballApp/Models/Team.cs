using System;

namespace PoolFootballApp.Models
{
	public enum Conference { AFC, NFC }
	public enum Division { East, North, South, West }

	public class Team
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string City { get; set; }
		public string ShortName { get; set; }

		public Conference Conf { get; set; }
		public Division Div { get; set; }
	}
}
