using GraphQL.Types;
using test.Requests;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace test.Models
{
    public class Person
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "homeworld")]
        public string Homeworld { get; set; }

        public string Created { get; set; }

        public string Edited { get; set; }

        public string Mass { get; set; }

        public string Height { get; set; }

        [JsonProperty(PropertyName = "hair_color")]
        public string HairColor { get; set; }

        [JsonProperty(PropertyName = "skin_color")]
        public string SkinColor { get; set; }

        [JsonProperty(PropertyName = "eye_color")]
        public string EyeColor { get; set; }

        [JsonProperty(PropertyName = "birth_year")]
        public string BirthYear { get; set; }

        public string Url { get; set; }
    }
}