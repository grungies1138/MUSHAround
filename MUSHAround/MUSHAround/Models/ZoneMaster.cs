using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSHAround.Models
{
    public class ZoneMaster
    {
        public string Name { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
        public List<string> Settings { get; set; }

        public ZoneMaster()
        {
            
        }
    }
}
