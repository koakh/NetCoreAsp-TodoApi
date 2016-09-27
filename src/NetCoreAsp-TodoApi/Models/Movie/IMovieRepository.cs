using NetCoreAspTodoApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreAspTodoApi.Models.Movies
{
    public interface IMovieRepository :  IRawSql<Movie>
    {
        IEnumerable<Movie> GetAll();
        void Add(Movie item);
        Movie Find(int key, bool readOnly = false);
        void Remove(int key);
        void Update(Movie item);
    }
}
