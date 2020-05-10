using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FootballLeague.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal FootballLeagueContext _context = null;
        internal DbSet<T> table = null;

        public Repository()
        {
            this._context = new FootballLeagueContext();
            table = _context.Set<T>();
        }

        public Repository(FootballLeagueContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return table.ToList();

        }

        public virtual T GetById(int id)
        {
            return table.Find(id);
        }

        public virtual void Create(T obj)
        {
            table.Add(obj);
            this.Save();
        }

        public virtual void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;

            this.Save();
        }

        public virtual void Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);

            this.Save();
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

    }
}
