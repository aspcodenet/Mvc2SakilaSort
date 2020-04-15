using System.Collections.Generic;

namespace Mvc2SakilaSort.ViewModels
{
    public class FileListViewModel
    {
        public List<FilmViewModel> Films { get; set; }
        public string SortOrder { get; set; }
        public string SortColumn { get; set; }

        public class FilmViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string ReleaseYear { get; set; }
        }
    }
}