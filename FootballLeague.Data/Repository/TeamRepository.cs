using FootballLeague.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Repository
{
    public class TeamRepository : Repository<Team>
    {
        public override IEnumerable<Team> GetAll()
        {
            return base.GetAll();
        }

        public override void Create(Team obj)
        {
            var team = this._context.Teams.FirstOrDefault(x => x.Name == obj.Name);
            if(team == null)
            {
                base.Create(obj);
            }
        }
    }
}
