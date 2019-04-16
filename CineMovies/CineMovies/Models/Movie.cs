using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CineMovies.Models
{
    public class Movie
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("genre_ids")]
        public List<int> GenreIds { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonIgnore]
        public string DateReleaseFormat => $"Lançamento: {ReleaseDate?.ToString("dd/MM/yyyy")}"; 

        [JsonIgnore]
        public string ImagePosterFormat => AppSettings.ImageOriginalUrl + PosterPath;

        [JsonIgnore]
        public string NameGenres { get; set; }


        [JsonIgnore]
        public int CountItem { get; set; }
    }
}
