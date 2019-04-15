using CineMovies.Models;
using CineMovies.Services.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CineMovies.Services.Movies
{
    public interface IMovieService
    {
        Task<Response<Movie>> GetMoviesAsync(string query, int page = 1);
    }
}
