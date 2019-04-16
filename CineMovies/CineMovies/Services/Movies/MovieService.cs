using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CineMovies.Models;
using CineMovies.Services.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CineMovies.Services.Movies
{
    public class MovieService : IMovieService
    {
        private IRequestService IRequestService = new RequestService();
        string url = string.Empty;

        public async Task<Response<Movie>> GetMoviesAsync(string query, int page = 1)
        { 
            if(string.IsNullOrEmpty(query))
                url = string.Format(AppSettings.MovieUpcoming, AppSettings.Language,page);
            else
                url = string.Format(AppSettings.SearchUrl, AppSettings.Language, query, page);

             return await IRequestService.GetAsync<Response<Movie>>(url);
        } 
    }
}
