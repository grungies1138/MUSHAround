using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSHAround.Models
{
    public class ParentRoom
    {
        public string Name { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
        public List<string> Flags { get; set; }
        public ParentRoom Parent { get; set; }
        public string Conformat { get; set; }
        public string Descformat { get; set; }
        public string Exitformat { get; set; }
        public string Nameformat { get; set; }
    }
}
