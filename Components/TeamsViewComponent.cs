using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PBMission13.Models;

namespace PBMission13.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private BowlingDbContext _repo { get; set; }

        // Constructor
        public TeamsViewComponent(BowlingDbContext temp)
        {
            _repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamName"];
            return View(_repo.Teams.Distinct().OrderBy(x => x));
        }
    }
}

