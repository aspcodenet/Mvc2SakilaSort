using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Mvc2SakilaSort.Models;

namespace Mvc2SakilaSort.Services
{
    public interface IMovieRepository
    {
        IEnumerable<Film> GetAll();
        Film Get(int id);
    }

    class MovieRepository : IMovieRepository
    {
        private readonly SakilaContext _context;

        public MovieRepository(SakilaContext context)
        {
            _context = context;
        }
        public IEnumerable<Film> GetAll()
        {
            return _context.Film;
        }

        public Film Get(int id)
        {
            return _context.Film.FirstOrDefault(f => f.FilmId == id);
        }
    }
}