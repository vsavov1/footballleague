using System;                                                       
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FootballLeague.Data;
using FootballLeague.Data.Models;
using FootballLeague.Data.Repository;

namespace FootballLeague.Controllers
{
    public class MatchesController : Controller
    {
        readonly IRepository<Match> matchesRepository;
        readonly IRepository<Team> teamsRepository;

        public MatchesController(IRepository<Match> repository, IRepository<Team> teamsRepository)
        {
            this.matchesRepository = repository;
            this.teamsRepository = teamsRepository;
        }

        // GET: Matches
        public ActionResult Index()
        {
            //var matches = db.Matches.Include(m => m.Guest).Include(m => m.Host);
            var matches = matchesRepository.GetAll();
            return View(matches.ToList());
        }

        // GET: Matches/Create
        public ActionResult Create()
        {

            ViewBag.GuestId = new SelectList(teamsRepository.GetAll(), "Id", "Name");
            ViewBag.HostId = new SelectList(teamsRepository.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GuestId,HostId,Result")] Match match)
        {
            if (ModelState.IsValid)
            {
                matchesRepository.Create(match);
            }

            return RedirectToAction("Index");
        }

        // GET: Matches/Edit/5
        public ActionResult Edit(int id)
        {
            Match match = matchesRepository.GetById(id);

            if (match == null)
            {
                return HttpNotFound();
            }

            ViewBag.GuestId = new SelectList(teamsRepository.GetAll(), "Id", "Name", match.GuestId);
            ViewBag.HostId = new SelectList(teamsRepository.GetAll(), "Id", "Name", match.HostId);

            return View("Edit");
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GuestId,HostId,Result")] Match match)
        {
            if (ModelState.IsValid)
            {
                matchesRepository.Update(match);
            }

            return RedirectToAction("Index");
        }

        // GET: Matches/Delete/5
        public ActionResult Delete(int id)
        {
            Match match = matchesRepository.GetById(id);

            if (match == null)
            {
                return HttpNotFound();
            }


            ViewBag.GuestId = new SelectList(teamsRepository.GetAll(), "Id", "Name", match.GuestId);
            ViewBag.HostId = new SelectList(teamsRepository.GetAll(), "Id", "Name", match.HostId);

            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = matchesRepository.GetById(id);

            if (match == null)
            {
                return HttpNotFound();
            }

            matchesRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
