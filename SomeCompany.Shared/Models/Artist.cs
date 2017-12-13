using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SomeCompany.Shared
{
    public class Artist
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("genres")]
        public string[] Genres { get; set; }

        [JsonProperty("popularity")]
        public int? Popularity { get; set; }
    }

    public class Artists
    {
        [JsonProperty("items")]
        public List<Artist> ArtistList { get; set; }
    }

    public class ArtistRoot
    {
        [JsonProperty("artists")]
        public Artists Artists { get; set; }
    }
}
