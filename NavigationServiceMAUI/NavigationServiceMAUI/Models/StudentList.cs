using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationServiceMAUI.Models
{
    internal class StudentList
    {
        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        public long? Page { get; set; }

        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public List<StudentModel> Results { get; set; }

        [JsonProperty("total_pages", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalPages { get; set; }

        [JsonProperty("total_results", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalResults { get; set; }
    }

    public partial class StudentModel
    {
        [JsonProperty("adult", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Adult { get; set; }

        [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
        public long? Gender { get; set; }



        [JsonProperty("known_for", NullValueHandling = NullValueHandling.Ignore)]
        public List<KnownFor> KnownFor { get; set; }

        [JsonProperty("known_for_department", NullValueHandling = NullValueHandling.Ignore)]
        public string KnownForDepartment { get; set; }



        [JsonProperty("popularity", NullValueHandling = NullValueHandling.Ignore)]
        public double? Popularity { get; set; }

        [JsonProperty("profile_path", NullValueHandling = NullValueHandling.Ignore)]
        public string ProfilePath { get; set; }
    }

    public partial class KnownFor
    {
        [JsonProperty("adult", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Adult { get; set; }

        [JsonProperty("backdrop_path", NullValueHandling = NullValueHandling.Ignore)]
        public string BackdropPath { get; set; }

        [JsonProperty("genre_ids", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> GenreIds { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("media_type", NullValueHandling = NullValueHandling.Ignore)]
        public string MediaType { get; set; }

        [JsonProperty("original_language", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalTitle { get; set; }

        [JsonProperty("overview", NullValueHandling = NullValueHandling.Ignore)]
        public string Overview { get; set; }

        [JsonProperty("poster_path", NullValueHandling = NullValueHandling.Ignore)]
        public string PosterPath { get; set; }

        [JsonProperty("release_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ReleaseDate { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("video", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Video { get; set; }

        [JsonProperty("vote_average", NullValueHandling = NullValueHandling.Ignore)]
        public double? VoteAverage { get; set; }

        [JsonProperty("vote_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? VoteCount { get; set; }

        [JsonProperty("first_air_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? FirstAirDate { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("origin_country", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> OriginCountry { get; set; }

        [JsonProperty("original_name", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalName { get; set; }
    }
}
