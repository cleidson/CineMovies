using CineMovies.Models;
using CineMovies.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CineMovies.ViewModels
{
    public class MovieDetailsViewModel: BaseViewModel
    {
        
        public string ImagePosterFormat { get; }
        public string MovieTitle { get;}
        public string NameGenres { get; }
        public string DateReleaseFormat { get; }
        public string DescriptionMovie { get; }

        public MovieDetailsViewModel(Movie movie):base("Detalhes do filme")
        {
            ImagePosterFormat = movie.ImagePosterFormat;
            MovieTitle = movie.Title;
            NameGenres = movie.NameGenres;
            DateReleaseFormat = movie.DateReleaseFormat;
            DescriptionMovie = movie.Overview;
        }

    }
}
