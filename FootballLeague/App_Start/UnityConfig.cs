using FootballLeague.Data.Models;
using FootballLeague.Data.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace FootballLeague
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IRepository<Team>, TeamRepository>();
            container.RegisterType<IRepository<Match>, MatchRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}