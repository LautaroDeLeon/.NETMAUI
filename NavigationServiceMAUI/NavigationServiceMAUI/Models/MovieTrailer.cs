using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationServiceMAUI.Models
{
    public partial class MovieTrailer
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public List<MovieTrailerModel> Results { get; set; }
    }

    public partial class MovieTrailerModel
    {
        [JsonProperty("iso_639_1", NullValueHandling = NullValueHandling.Ignore)]
        public string Iso639_1 { get; set; }

        [JsonProperty("iso_3166_1", NullValueHandling = NullValueHandling.Ignore)]
        public string Iso3166_1 { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        [JsonProperty("site", NullValueHandling = NullValueHandling.Ignore)]
        public string Site { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public long? Size { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }
}
