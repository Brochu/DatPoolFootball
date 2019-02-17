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

        public DbSet<Team> Team { get; set; }
    }
}
