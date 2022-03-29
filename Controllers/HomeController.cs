using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PBMission13.Models;
using PBMission13.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace PBMission13.Controllers
{
    public class HomeController : Controller
    {
        private BowlingDbContext _repo { get; set; }

        // Constructor
        public HomeController(BowlingDbContext temp)
        {
            _repo = temp;
        }

        public IActionResult Index(long teamID, string teamName)
        {   
            // Display team name on top of page
            ViewBag.Header = teamName;

            // Display bowlers
            // Filter by BowlerID so that the most recently added bowler is at the bottom            
            var Bowlers = (_repo.Bowlers
                .Where(x => x.TeamID == teamID || teamID == 0)
                .OrderBy(x => x.BowlerID)
                .ToList());

            // Correctly display the team name associated with each bowler
            foreach (Bowler bowler in Bowlers)
            {
                bowler.Team = _repo.Teams.Single(x => x.TeamID == bowler.TeamID);
            }
            
            return View(new ViewModel
            {
                Bowlers = Bowlers,
                TeamName = teamName,
            });

        }

        // Add Bowlers
        [HttpGet]
        public IActionResult AddBowler()
        {
            ViewBag.Teams = _repo.Teams.ToList();

            ViewBag.Bowlers = _repo.Bowlers.ToList();

            var BowlInfo = _repo.Bowlers.ToList();

            ViewBag.lengthIndex = BowlInfo.Count + 1;

            var x = new Bowler();

            return View(x);
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(b);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Teams = _repo.Teams.ToList();
                return View();
            }
        }

        // Edit Bowlers
        [HttpGet]
        public IActionResult EditBowler(int id)
        {
            ViewBag.Teams = _repo.Teams.ToList();

            var edit = _repo.Bowlers.Single(x => x.BowlerID == id);

            return View("EditBowler", edit);
        }

        [HttpPost]
        public IActionResult EditBowler(Bowler editedBowler)
        {
            _repo.Update(editedBowler);
            _repo.SaveChanges();

            return RedirectToAction("Index");
        }

        // Delete Bowlers
        [HttpGet]
        public IActionResult DeleteBowler(int id)
        {
            var Bowler = _repo.Bowlers.Single(x => x.BowlerID == id);

            return View(Bowler);
        }

        [HttpPost]
        public IActionResult DeleteBowler(Bowler deletedBowler)
        {
            _repo.Bowlers.Remove(deletedBowler);
            _repo.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
