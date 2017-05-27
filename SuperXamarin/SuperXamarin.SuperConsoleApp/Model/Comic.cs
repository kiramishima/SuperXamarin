using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperXamarin.PCL.Model
{
    public class Comic
    {
        public int Avalaible { get; set; }
        public string CollectionURI { get; set; }
        public List<ComicItem> Items { get; set; }
        public int Returned { get; set; }
    }

    public class ComicItem
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
    }
}
