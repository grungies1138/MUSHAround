using System.Collections.Generic;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace MUSHAround.Models
{
    public class Exit : Thumb
    {
        public List<LineGeometry> StartingLines { get; set; }
        public List<LineGeometry> EndingLines { get; set; }

        public string ExitName { get; set; }
        public string ReturnName { get; set; }
        public Room Location { get; set; }
        public Room Destination { get; set; }
        public string DropMessage { get; set; }
        public string SuccessMessage { get; set; }
        public string OSuccessMessage { get; set; }

        public Exit()
        {
            StartingLines = new List<LineGeometry>();
            EndingLines = new List<LineGeometry>();
        }
    }
}
