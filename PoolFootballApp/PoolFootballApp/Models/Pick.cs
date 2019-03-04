using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolFootballApp.Models
{
	public enum MatchPick { None, Away, Home }

	public class Pick
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public int MatchId { get; set; }
		public MatchPick Choice { get; set; }

		public virtual Match Match { get; set; }
	}
}
