using FootballLeague.Data.Models;
using FootballLeague.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballLeague.Controllers
{
    public class TeamController : Controller
    {
        readonly IRepository<Team> teamRepository;
        public TeamController(IRepository<Team> repository)
        {
            this.teamRepository = repository;
        }

        // GET: User  
        public ActionResult Index()
        {
            var data = teamRepository.GetAll();
            return View(data);
        }

        // GET: Team/Details/5
        public ActionResult Details(int id)
        {                
            //todo, maybe to show played matched of that team
            return View();
        }

        // GET: Team/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Team/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                teamRepository.Create(new Team { Name = collection["Name"] });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Team/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Team/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                teamRepository.Update(new Team { Id = id, Name = collection["Name"] });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Team/Delete/5
        public ActionResult Delete(int id)
        {
            teamRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
