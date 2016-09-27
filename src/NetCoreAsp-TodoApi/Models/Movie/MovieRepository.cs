using Microsoft.EntityFrameworkCore;
using NetCoreAspTodoApi.Data;
using NetCoreAspTodoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAspTodoApi.Models.Movies
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        //DI Inject ApplicationDbContext
        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAll()
        {
            var movie = _context.Movie;
            return movie;
        }

        public virtual IEnumerable<Movie> SqlQuery(string query, params object[] parameters)
        {
            return _context.Movie.FromSql(query).AsEnumerable<Movie>();
        }

        public Movie Find(int key, bool readOnly = false)
        {
            var movie = (!readOnly)
                ? _context.Movie.SingleOrDefault(m => m.ID == key)
                //Avoids having the entities be tracked by the context
                : _context.Movie.AsNoTracking().SingleOrDefault(m => m.ID == key)
            ;
            return movie;
        }

        public void Add(Movie item)
        {
            _context.Movie.Add(item);
            _context.SaveChanges();
        }

        public void Remove(int key)
        {
            Movie movie = Find(key); ;
            _context.Movie.Remove(movie);
            _context.SaveChanges();
        }
        
        public void Update(Movie item)
        {
            try
            {
                _context.Movie.Update(item);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }
    }
}
