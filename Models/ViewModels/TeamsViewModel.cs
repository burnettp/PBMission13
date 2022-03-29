using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBMission13.Models.ViewModels
{
    public class ViewModel
    {
        public IEnumerable<Bowler> Bowlers { get; set; }
        public string TeamName { get; set; }
    }
}
