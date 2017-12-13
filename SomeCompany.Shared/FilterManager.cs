using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using SpotifyWebApi.Factory;
using SpotifyWebApi.Model.Auth;

namespace SomeCompany.Shared
{
    public class FilterManager
    {
        static Token _token;

        public static List<Artist> SearchArtist(string artist)
        {
            var tokenFactory = new TokenFactory(ConfigurationManager.AppSettings["SpotifyClientId"], ConfigurationManager.AppSettings["SpotifyClientSecret"], TokenMethod.ClientCredentialsAuth);

            _token = tokenFactory.GetToken();

            var url = "https://api.spotify.com/v1/search?query=*" + artist + "*&offset=0&limit=5&type=artist";

            var result = RequestData(_token, url);
            var artists = JsonConvert.DeserializeObject<ArtistRoot>(result);

            return artists.Artists.ArtistList;
        }

        public static List<Suggestions> GetSuggestions(string artistId)
        {
            var tokenFactory = new TokenFactory(ConfigurationManager.AppSettings["SpotifyClientId"], ConfigurationManager.AppSettings["SpotifyClientSecret"], TokenMethod.ClientCredentialsAuth);

            _token = tokenFactory.GetToken();

            var url = "https://api.spotify.com/v1/artists/" + artistId + "/related-artists";

            var result = RequestData(_token, url);
            var artists = JsonConvert.DeserializeObject<SuggestionRoot>(result);

            return artists.Suggestions;
        }

        private static string RequestData(Token token, string url)
        {
            var json = "";

            var request = WebRequest.Create(url);

            var headers = new NameValueCollection { ["Authorization"] = token.Type + " " + token.AccessToken };
            request.ContentType = "application/x-www-form-urlencoded";

            request.Headers = new WebHeaderCollection { headers };

            WebResponse response;
            try
            {
                response = request.GetResponse();
            }
            catch (Exception)
            {
                return null;
            }

            var dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            json += reader.ReadToEnd();

            return json;
        }

        public static List<string> GetGenres(List<Suggestions> suggestions)
        {
            var genres = new List<string>();
            foreach (var sugestion in suggestions)
            {
                genres.AddRange(sugestion.Genres.Where(genre => !genres.Contains(genre)));
            }
            return genres;
        }
    }
}
