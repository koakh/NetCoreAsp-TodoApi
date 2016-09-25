using System.Collections.Generic;

namespace NetCoreAspTodoApi.Models.Movies
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        void Add(Movie item);
        Movie Find(int key);
        void Remove(int key);
        void Update(Movie item);
    }
}
