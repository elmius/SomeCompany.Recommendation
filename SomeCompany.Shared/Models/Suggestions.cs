using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SomeCompany.Shared
{
    public class SuggestionRoot
    {
        [JsonProperty("artists")]
        public List<Suggestions> Suggestions { get; set; }
    }

    public class Suggestions
    {
        [JsonProperty("genres")]
        public string[] Genres { get; set; }

        public string GenresAsString => string.Join(",", Genres);

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("popularity")]
        public int? Popularity { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("images")]
        public List<ImageObjects> ImageObjects { get; set; }
    }

    public class ImageObjects
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public string Url { get; set; }
    }
}
