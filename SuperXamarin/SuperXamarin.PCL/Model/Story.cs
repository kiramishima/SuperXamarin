using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperXamarin.PCL.Model
{
    public class Story
    {
        public int Avalaible { get; set; }
        public string CollectionURI { get; set; }
        public List<StoryItem> Items { get; set; }
        public int Returned { get; set; }
    }

    public class StoryItem
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
