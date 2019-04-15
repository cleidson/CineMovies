using CineMovies.Models;
using CineMovies.Services.Movies;
using CineMovies.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace CineMovies.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        #region Ctor
        private readonly IMovieService MoviesService;

        public MoviesViewModel():base("Movies")
        {
            MoviesService = new MovieService();

            Task.Run(async () => {
                await PopulateListAsync();
            });
        }

        #endregion


        private ObservableCollection<Movie> movies =
            new ObservableCollection<Movie>();

        public ObservableCollection<Movie> Movies
        {
            get { return movies; }
            set
            {
                movies = value;
                OnPropertyChanged();
            }
        }

        async Task PopulateListAsync(int page = 1, string query = null)
        {
            IsBusy = true;
            var movies = await MoviesService.GetMoviesAsync(query, page);

            movies.Results.ForEach(x =>
            { 
                Movies.Add(x);
            }); 
            IsBusy = false;
        } 
    }
}
