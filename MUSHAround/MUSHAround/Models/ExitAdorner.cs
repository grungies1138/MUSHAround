using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace MUSHAround.Models
{
    public class ExitAdorner : Adorner
    {
        public Exit Exit { get; set; }
        private SolidColorBrush renderBrush;

        public ExitAdorner(UIElement adornedElement) : base(adornedElement)
        {
            //Todo
            renderBrush = new SolidColorBrush(Colors.White);
            Exit = new Exit();
            Room owner = adornedElement as Room;
            owner.Exits.Add(Exit);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            //base.OnRender(drawingContext);
            Rect adornedRect = new Rect(this.AdornedElement.DesiredSize);

            //SolidColorBrush renderBrush = new SolidColorBrush(Colors.Beige);
            renderBrush.Opacity = 1;
            Pen renderPen = new Pen(new SolidColorBrush(Colors.Black), 1);
            double renderRadius = 4.0;

            drawingContext.DrawEllipse(renderBrush, renderPen, new Point(adornedRect.Top + (adornedRect.Width/2),adornedRect.Top), renderRadius, renderRadius);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            //base.OnMouseLeftButtonDown(e);
            MessageBox.Show("Clicked!");
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            renderBrush = new SolidColorBrush(Colors.Black);
            InvalidateVisual();
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            renderBrush = new SolidColorBrush(Colors.White);
            InvalidateVisual();
        }

        
    }
}
