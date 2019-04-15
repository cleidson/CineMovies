using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CineMovies.Services
{
    public class Response<T>
    {
        [JsonProperty("results")]
        public IReadOnlyList<T> Results { get; private set; } 

        [JsonProperty("page")]
        public int PageNumber { get; private set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; private set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; private set; }  
    }
 
}
