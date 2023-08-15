using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationServiceMAUI.Models
{
    internal class ImageList
    {
        [JsonProperty("backdrops", NullValueHandling = NullValueHandling.Ignore)]
        public List<ImageModel> Backdrops { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("logos", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Logos { get; set; }

        [JsonProperty("posters", NullValueHandling = NullValueHandling.Ignore)]
        public List<ImageModel> Posters { get; set; }
    }

    public partial class ImageModel
    {
        [JsonProperty("aspect_ratio", NullValueHandling = NullValueHandling.Ignore)]
        public double? AspectRatio { get; set; }

        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public long? Height { get; set; }

        [JsonProperty("iso_639_1")]
        public string Iso639_1 { get; set; }

        [JsonProperty("file_path", NullValueHandling = NullValueHandling.Ignore)]
        public string FilePath { get; set; }

        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public long? Width { get; set; }
    }
}