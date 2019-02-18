using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoolFootballApp.Models
{
	public enum Conference { AFC, NFC }
	public enum Division { East, North, South, West }

	public class Team
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public string ShortName { get; set; }
		public string Name { get; set; }
		public string City { get; set; }

		public Conference Conf { get; set; }
		public Division Div { get; set; }

		public virtual ICollection<Match> HomeMatches { get; set; }
		public virtual ICollection<Match> AwayMatches { get; set; }
	}
}
