using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBMission13.Models
{
    public class BowlingDbContext : DbContext
    {
        public BowlingDbContext(DbContextOptions<BowlingDbContext> options) : base(options)
        {

        }

        public DbSet<Bowler> Bowlers { get; set; } // We are going to get a bunch of individual instances of Bowler and put them in a list of Bowlers
        public virtual DbSet<Team> Teams { get; set; }
    }
}
