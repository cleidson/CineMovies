using CineMovies.Models;
using CineMovies.Services.Genres;
using CineMovies.Services.Movies;
using CineMovies.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace CineMovies.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        #region properties
        private readonly IMovieService MoviesService;
        private readonly IGenreService GenresService;
        private ObservableCollection<Movie> movies = new ObservableCollection<Movie>();
        int totalPages = 1;


        private bool isRefreshing;

        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetProperty(ref isRefreshing, value);
        }


        private string searchBar;

        public string SearchBar
        {
            get => searchBar;
            set => SetProperty(ref searchBar, value);
        }



        public Command<int> SearchBarCommand { get; }

        public Command<int> MoviesCommand { get; }

        public ObservableCollection<Movie> Movies
        {
            get { return movies; }
            set
            {
                movies = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Ctor
        public MoviesViewModel():base("Movies")
        {
            MoviesService = new MovieService();
            GenresService = new GenreService();
            MoviesCommand = new Command<int>(async (e) => await GetMovies(e));
            SearchBarCommand = new Command<int>(async (e) => await SearchMovie(e));   
        }
        #endregion 

        public async Task SearchMovie(int page = 1)
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                if (page == 1 && !string.IsNullOrEmpty(SearchBar))
                    Movies.Clear();

                await LoadListAsync(page, SearchBar);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro", $"Erro:{ex.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }


        public async Task GetMovies(int page = 1)
        {
            if (IsBusy || page > totalPages)
            {
                return;
            }

            try
            {
                IsBusy = true;
                await LoadListAsync(page, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro", $"Erro:{ex.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task LoadListAsync(int page = 1, string query = null)
        { 
            IsRefreshing = true;
            var movies = await MoviesService.GetMoviesAsync(query, page);
            var genries = await GenresService.GetGenresAsync();

            totalPages = movies.TotalPages; 

            movies.Results.ForEach(x =>
            {
                x.CountItem = (Movies.Count) + 1;
                x.NameGenres = "Gêneros: " + string.Join(", ", genries.Genres.Where(t => x.GenreIds.Contains(t.Id)).Select(y => y.Name));
                Movies.Add(x);
            });

            IsRefreshing = false;
        }

 
    }
}
