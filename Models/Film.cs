using GraphQL.Types;
using test.Requests;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace test.Models
{
    public class Film
    {
        public string Title { get; set; }

        [JsonProperty(PropertyName = "episode_id")]
        public int EpisodeID { get; set; }

        [JsonProperty(PropertyName = "opening_crawl")]
        public string OpeningCrawl { get; set; }

        public string Director { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public string ReleaseDate { get; set; }

        public string Created { get; set; }

        public string Edited { get; set; }

        public string Producer { get; set; }

        public string[] Characters { get; set; }
    }
}