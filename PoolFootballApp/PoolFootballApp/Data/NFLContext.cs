﻿using System;
using Microsoft.EntityFrameworkCore;

namespace PoolFootballApp.Models
{
	public class NFLContext : DbContext
	{
		public NFLContext (DbContextOptions<NFLContext> options)
			: base(options)
		{
		}

		public DbSet<Team> Teams { get; set; }
		public DbSet<Match> Matches { get; set; }
		public DbSet<Pick> Picks { get; set; }
	}
}
