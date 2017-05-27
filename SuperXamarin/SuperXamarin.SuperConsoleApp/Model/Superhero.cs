using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperXamarin.PCL.Model
{
    public class Superhero
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "modified")]
        public string Modified { get; set; }
        [JsonProperty(PropertyName = "thumbnail")]
        public Thumbnail Thumbnail { get; set; }
        [JsonProperty(PropertyName = "resourceURI")]
        public string ResourceURI { get; set; }
        [JsonProperty(PropertyName = "comics")]
        public Comic Comics { get; set; }
        [JsonProperty(PropertyName = "series")]
        public Serie Series { get; set; }
        [JsonProperty(PropertyName = "stories")]
        public Story Stories { get; set; }
        [JsonProperty(PropertyName = "events")]
        public Event Events { get; set; }
        [JsonProperty(PropertyName = "urls")]
        public List<Url> Urls { get; set; }
    }

    public class Url
    {
        [JsonProperty(PropertyName = "url")]
        public string URL { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
