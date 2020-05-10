using System.Collections.Generic;
using FootballLeague.Data.Models;
using System.Linq;

namespace FootballLeague.Data.Repository
{
    public class MatchRepository : Repository<Match>
    {
        public override IEnumerable<Match> GetAll()
        {
            return _context.Matches.Include("Guest").Include("Host");
        }
    }
}
