﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolFootballApp.Models
{
	public enum MatchPick { Home, Away }

	public class Pick
	{
		public int Id { get; set; }
		public int MatchId { get; set; }
		public MatchPick Choice { get; set; }

		public virtual Match Match { get; set; }
	}
}
