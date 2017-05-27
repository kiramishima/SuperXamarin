using Newtonsoft.Json;
using System.Collections.Generic;

namespace SuperXamarin.PCL.Model
{
    public class CharacterDataWrapper<T>
    {
        [JsonProperty(PropertyName = "code ")]
        public int Code { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "copyright")]
        public string Copyright { get; set; }
        [JsonProperty(PropertyName = "attributionText")]
        public string AttributionText { get; set; }
        [JsonProperty(PropertyName = "attributionHTML")]
        public string AttributionHTML { get; set; }
        [JsonProperty(PropertyName = "data")]
        public CharacterDataContainer<T> Data { get; set; }
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }
    }

    public class CharacterDataContainer<T>
    {
        [JsonProperty(PropertyName = "offset")]
        public int Offset { get; set; }
        [JsonProperty(PropertyName = "limit")]
        public int Limit { get; set; }
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
        [JsonProperty(PropertyName = "results")]
        public List<T> Results { get; set; }
    }
}
