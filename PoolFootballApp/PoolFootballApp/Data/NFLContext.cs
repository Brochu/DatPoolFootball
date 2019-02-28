using System;
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
		public DbSet<Message> Messages { get; set; }
		public DbSet<Pool> Pools { get; set; }
	}
}
