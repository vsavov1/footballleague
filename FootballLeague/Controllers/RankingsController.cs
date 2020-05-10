using FootballLeague.Data.Repository;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Linq;
using FootballLeague.Data.Models;
using Match = FootballLeague.Data.Models.Match;
using FootballLeague.Data.Models.Enums;

namespace FootballLeague.Controllers
{
    public class RankingsController : Controller
    {
        readonly IRepository<Match> matchesRepository;
        readonly IRepository<Team> teamsRepository;

        public RankingsController(IRepository<Match> repository, IRepository<Team> teamsRepository)
        {
            this.matchesRepository = repository;
            this.teamsRepository = teamsRepository;
        }

        // GET: Ranking
        public ActionResult Index()
        {
            var result = teamsRepository
                .GetAll()
                .Select(t => new Rank()
                {
                    Team = t,
                    Score = matchesRepository
                        .GetAll()
                        .Where(m => m.GuestId == t.Id || m.HostId == t.Id)
                        .Sum(r => 
                            r.Result == Result.Tie ? 1 : 
                            r.Result == Result.Win && r.HostId == t.Id ? 3 : 
                            r.Result == Result.Lose && r.GuestId == t.Id ? 3 : 0)
                })
                .OrderByDescending(o => o.Score)
                .ToList();


            return View(result);
        }
    }
}