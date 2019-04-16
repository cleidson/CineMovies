using CineMovies.Services.Genres;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinemovies.Test.Services.Genres
{
    
    [TestClass]
    public class GenreServiceTest
    {
        protected IGenreService _GenreService;
        
        [TestMethod]
        public async Task GetGenresAsync()
        {
            _GenreService = new GenreService();
            var result = await _GenreService.GetGenresAsync();
            Assert.IsNotNull(result);
        } 
    }
}
