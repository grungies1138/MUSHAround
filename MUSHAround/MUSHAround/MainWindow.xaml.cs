using MUSHAround.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;

namespace MUSHAround
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const double ScaleRate = 1.1;
        private Room firstRoom;
        private Room secondRoom;

        public MainWindow()
        {
            InitializeComponent();

            firstRoom = new Room();

            firstRoom.RoomName = "First Room";
            firstRoom.DataContext = firstRoom;
            firstRoom.Template = (ControlTemplate) this.FindResource("roomRect");
            firstRoom.AllowDrop = true;
            
            firstRoom.DragDelta += FirstRoom_OnDragDelta;
            RoomCanvas.Children.Add(firstRoom);
            Canvas.SetLeft(firstRoom, 0);
            Canvas.SetTop(firstRoom, 0);


            secondRoom = new Room();
            secondRoom.RoomName = "Second Room";
            secondRoom.DataContext = secondRoom;
            secondRoom.Template = (ControlTemplate) this.FindResource("roomRect");
            secondRoom.AllowDrop = true;
        
            secondRoom.DragDelta += FirstRoom_OnDragDelta;
            RoomCanvas.Children.Add(secondRoom);
            Canvas.SetTop(secondRoom, 100);
            Canvas.SetLeft(secondRoom, 200);

            
        }

        private void RoomCanvas_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                canvasST.ScaleX *= ScaleRate;
                canvasST.ScaleY *= ScaleRate;
            }
            else
            {
                canvasST.ScaleX /= ScaleRate;
                canvasST.ScaleY /= ScaleRate;
            }
        }

        private void FirstRoom_OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            if (e.Source is Room room)
            {
                Canvas.SetLeft(room, Canvas.GetLeft(room) + e.HorizontalChange);
                Canvas.SetTop(room, Canvas.GetTop(room) + e.VerticalChange);
            }
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            List<Room> rooms = new List<Room>();
            List<Exit> exits = new List<Exit>();

            foreach (UIElement child in RoomCanvas.Children)
            {
                if (child.GetType() == typeof(Room))
                {
                    rooms.Add(child as Room);
                }
            }

            foreach (Room room in rooms)
            {
                
            }
        }

        private void UpdateLines(Exit exit)
        {
            double left = Canvas.GetLeft(exit);
            double top = Canvas.GetTop(exit);

            for (int i = 0; i < exit.StartingLines.Count; i++)
            {
                exit.StartingLines[i].StartPoint = new Point(left + exit.ActualWidth / 2, top + exit.ActualHeight /2);
            }

            for (int i = 0; i < exit.EndingLines.Count; i++)
            {
                exit.EndingLines[i].EndPoint = new Point(left + exit.ActualWidth / 2, top + exit.ActualHeight /2);
            }
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;

            StackPanel sp = ((ContextMenu) item.Parent).PlacementTarget as StackPanel;
            Room selectedRoom = sp.TemplatedParent as Room;
            var myAdornerLayer = AdornerLayer.GetAdornerLayer(selectedRoom);
            myAdornerLayer.Add(new ExitAdorner(selectedRoom));
        }

        private void NewRoom_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        public void AddRoom(Room newRoom)
        {

        }
    }
}
