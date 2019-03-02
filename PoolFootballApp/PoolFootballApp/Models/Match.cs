using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoolFootballApp.Models
{
	/// <summary>
	/// To order matches in the correct order
	/// </summary>
	public enum Day { Tue, Wed, Thu, Fri, Sat, Sun, Mon }

	public class Match
	{
		public int Id { get; set; }
		public int Season { get; set; }
		public int Week { get; set; }
		public Day WeekDay { get; set; }
		public DateTime StartTime { get; set; }

		public string HomeTeamId { get; set; }
		public string AwayTeamId { get; set; }

		public int HomeScore { get; set; }
		public int AwayScore { get; set; }

		// LINKS TO OTHER TABLES
		[ForeignKey("HomeTeamId")]
		[InverseProperty("HomeMatches")]
		public virtual Team HomeTeam { get; set; }
		[ForeignKey("AwayTeamId")]
		[InverseProperty("AwayMatches")]
		public virtual Team AwayTeam { get; set; }

		public virtual ICollection<Pick> Picks { get; set; }
	}
}
