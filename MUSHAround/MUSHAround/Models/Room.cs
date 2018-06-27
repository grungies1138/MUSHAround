using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;

namespace MUSHAround.Models
{
    public class Room : Thumb, INotifyPropertyChanged
    {
        private string _roomeName;
        private string _description;

        public string RoomName
        {
            get => _roomeName;

            set
            {
                if (value != _roomeName)
                {
                    _roomeName = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("RoomName"));
                }
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (value != _description)
                {
                    _description = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Description"));
                }
            }
        }
        public Dictionary<string, string> Attributes { get; set; }
        public ParentRoom ParentRoom { get; set; }
        public ZoneMaster ZoneMaster { get; set; }
        public List<Exit> Exits { get; set; }
        public List<string> Flags { get; set; }
        public string Conformat { get; set; }
        public string Descformat { get; set; }
        public string Exitformat { get; set; }
        public string Nameformat { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Room()
        {
            Attributes = new Dictionary<string, string>();
            Flags = new List<string>();
            Exits = new List<Exit>();
        }

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);
            if (e.Source is Exit)
            {
                System.Windows.Forms.MessageBox.Show("Dropped an exit!");
            }
            
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            Room source = e.Source as Room;
            var adornerLayer = AdornerLayer.GetAdornerLayer(this);
            adornerLayer.Add(new ResizeAdorner(source));
        }

        public void Redraw()
        {
            InvalidateVisual();
        }
    }
}
