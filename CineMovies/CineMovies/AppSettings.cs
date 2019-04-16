using System;
using System.Collections.Generic;
using System.Text;

namespace CineMovies
{
    /// <summary>
    /// TODO: Verificar depois o AppSettings
    /// </summary>
    public static class AppSettings
    {
        #region Config Api
        public static string ApiUrl = "https://api.themoviedb.org/";
        public static string ApiVersion = "/3";
        public static string ApiKey = "?api_key=1f54bd990f1cdfb230adb312546d765d";
        #endregion

        #region Config Common
        public static string Language = "pt-BR";
        public static string UpComing = "/upcoming";
        public static string ImageOriginalUrl = "https://image.tmdb.org/t/p/original/";
        #endregion


        #region Movie and Genre
        public static string Movie = "/movie";
        public static string MovieUpcoming = ApiVersion + Movie + UpComing + ApiKey + "&language={0}&page={1}";

        public static string Genre = "/genre";
        public static string GenreList = ApiVersion + Genre + Movie + "/list" + ApiKey + "&language={0}";
        #endregion


        #region Search
        public static string Search = "/search";
        public static string SearchUrl = ApiVersion + Search + Movie + ApiKey + "&language={0}" + "&query={1}" + "&page={2}";
        #endregion

    }
}
