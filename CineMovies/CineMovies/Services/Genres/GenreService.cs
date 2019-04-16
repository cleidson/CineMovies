using CineMovies.DataTransferObjects;
using CineMovies.Models;
using CineMovies.Services.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CineMovies.Services.Genres
{
    public class GenreService : IGenreService
    {

        private IRequestService IRequestService = new RequestService();
        string url = string.Empty;

        public async Task<GenreDto> GetGenresAsync()
        { 
            url = string.Format(AppSettings.GenreList, AppSettings.Language); 
            return await IRequestService.GetAsync<GenreDto>(url);
        } 
    }
}
