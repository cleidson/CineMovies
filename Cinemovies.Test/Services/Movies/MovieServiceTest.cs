using CineMovies.Services.Movies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinemovies.Test.Services.Movies
{ 
    [TestClass]
    public class MovieServiceTest
    {
        protected IMovieService _MovieService;

        [TestMethod]
        public async Task GetMoviesAsyncWithFilter()
        {
            _MovieService = new MovieService();  
            var result = await _MovieService.GetMoviesAsync("The facebook", 1);
            Assert.IsNotNull(result.Results);  
        }

        [TestMethod]
        public async Task GetMoviesAsyncNoFilter()
        {
            _MovieService = new MovieService();
            var result = await _MovieService.GetMoviesAsync(null, 1);
            Assert.IsNotNull(result.Results);
        }
    }
}
