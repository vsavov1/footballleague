using FootballLeague.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data
{
    public class FootballLeagueContext : DbContext
    {
        public FootballLeagueContext()  
            : base("name=FootballLeagueConnectionString")  
        {
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
