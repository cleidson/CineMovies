using CineMovies.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CineMovies.DataTransferObjects
{
    public class GenreDto
    {
        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; } = new List<Genre>();
    }
}
