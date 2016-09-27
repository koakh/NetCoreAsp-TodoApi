using System;
using System.Collections.Generic;
using System.Linq;

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

        public Movie Find(int key)
        {
            var movie = _context.Movie.SingleOrDefault(m => m.ID == key);
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
        
        //http://www.asp.net/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/advanced-entity-framework-scenarios-for-an-mvc-web-application
        public void Update(Movie item)
        {
            _context.Movie.Update(item);
            _context.SaveChanges();
        }
    }
}
