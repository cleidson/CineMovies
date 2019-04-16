using CineMovies.DataTransferObjects;
using CineMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CineMovies.Services.Genres
{
    public interface IGenreService
    {
        Task<GenreDto> GetGenresAsync();
    }
}
