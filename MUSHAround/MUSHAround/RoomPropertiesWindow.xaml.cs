using MUSHAround.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MUSHAround
{
    /// <summary>
    /// Interaction logic for RoomPropertiesWindow.xaml
    /// </summary>
    public partial class RoomPropertiesWindow : Window
    {
        public Room Room { get; set; }
        public RoomPropertiesWindow()
        {
            InitializeComponent();
            Room = new Room();
            DataContext = Room;
        }

        public RoomPropertiesWindow(Room room)
        {
            Room = room;
            DataContext = Room;
        }
    }
}
