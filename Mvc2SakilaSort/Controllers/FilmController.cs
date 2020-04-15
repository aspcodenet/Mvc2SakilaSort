using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mvc2SakilaSort.Services;
using Mvc2SakilaSort.ViewModels;

namespace Mvc2SakilaSort.Controllers
{
    public class FilmController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public FilmController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET
        public IActionResult Index(string sortcolumn, string sortorder)
        {
            var model = new FileListViewModel();
            var query = _movieRepository.GetAll().Select(r => new FileListViewModel.FilmViewModel
            {
                Id = r.FilmId,
                ReleaseYear = r.ReleaseYear,
                Title = r.Title
            });

            query = AddSorting(query,ref sortcolumn,ref sortorder);

            model.Films = query.ToList();
            model.SortColumn = sortcolumn;
            model.SortOrder = sortorder;
            return View(model);
        }

        private IEnumerable<FileListViewModel.FilmViewModel> AddSorting(IEnumerable<FileListViewModel.FilmViewModel> query, ref string sortcolumn, ref string sortorder)
        {
            if (string.IsNullOrEmpty(sortcolumn))
                sortcolumn = "id";
            if (string.IsNullOrEmpty(sortorder))
                sortorder = "asc";

            switch (sortcolumn)
            {
                case "id":
                    if (sortorder == "desc")
                        query = query.OrderByDescending(r => r.Id);
                    else
                        query = query.OrderBy(r => r.Id);
                    break;
                case "namn":
                    if (sortorder == "desc")
                        query = query.OrderByDescending(r => r.Title);
                    else
                        query = query.OrderBy(r => r.Title);
                    break;
                case "datum":
                    if (sortorder == "desc")
                        query = query.OrderByDescending(r => r.ReleaseYear);
                    else
                        query = query.OrderBy(r => r.ReleaseYear);
                    break;

            }

            return query;
        }
    }
}