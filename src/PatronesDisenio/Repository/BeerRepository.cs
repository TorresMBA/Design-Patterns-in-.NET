using PatronesDisenio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDisenio.Repository
{
    public class BeerRepository : IBeerRepository
    {
        private readonly DesignPatternsContext _context;

        public BeerRepository(DesignPatternsContext context)
        {
            _context = context;
        }

        public void Add(Beer data)
        {
            _context.Beers.Add(data);
        }

        public void Delete(int id)
        {
            var berr = _context.Beers.Find(id);

            _context.Beers.Remove(berr);
        }

        public IEnumerable<Beer> Get() => _context.Beers.ToList();

        public Beer Get(int id) => _context.Beers.Find(id);

        public void Update(Beer data)
        {
            _context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
