using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBMission13.Models
{
    public class EFBowlingRepository : IBowlingRepository
    {
        private BowlingDbContext _context { get; set; }

        public EFBowlingRepository (BowlingDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;
    }
}
