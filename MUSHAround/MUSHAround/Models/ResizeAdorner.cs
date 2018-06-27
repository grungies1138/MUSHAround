using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace MUSHAround.Models
{
    public class ResizeAdorner : Adorner
    {
        private Thumb bottomRight;

        private VisualCollection visualChildren;

        protected override int VisualChildrenCount { get { return visualChildren.Count; } }
        protected override Visual GetVisualChild(int index) { return visualChildren[index]; }
    

    public ResizeAdorner(UIElement adornedElement) : base(adornedElement)
        {
            visualChildren = new VisualCollection(this);

            BuildAdornerCorner(ref bottomRight, System.Windows.Input.Cursors.SizeNWSE);

            //bottomRight.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(BottomRight_PreviewMouseLeftButtonDown);
            bottomRight.DragDelta += new DragDeltaEventHandler(HandleBottomRight);

        }

        void BuildAdornerCorner(ref Thumb cornerThumb, System.Windows.Input.Cursor customCursor)
        {
            if (cornerThumb != null) return;
            cornerThumb = new Thumb();
            cornerThumb.Cursor = customCursor;
            cornerThumb.Height = cornerThumb.Width = 10;
            cornerThumb.Opacity = 1;
            cornerThumb.Background = new SolidColorBrush(Colors.Black);

            visualChildren.Add(cornerThumb);
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            this.Cursor = System.Windows.Input.Cursors.SizeNWSE;
        }

        void HandleBottomRight(object sender, DragDeltaEventArgs args)
        {
            FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;
            Thumb hitThumb = sender as Thumb;

            if (adornedElement == null || hitThumb == null) return;
            FrameworkElement parentElement = adornedElement.Parent as FrameworkElement;

            EnforceSize(adornedElement);

            adornedElement.Width = Math.Max(adornedElement.Width + args.HorizontalChange, hitThumb.DesiredSize.Width);
            adornedElement.Height = Math.Max(adornedElement.Height + args.VerticalChange, hitThumb.DesiredSize.Height);
        }

        private void EnforceSize(FrameworkElement adornedElement)
        {
            if (adornedElement.Width.Equals(Double.NaN))
            {
                adornedElement.Width = adornedElement.DesiredSize.Width;
            }

            if (adornedElement.Height.Equals(Double.NaN))
            {
                adornedElement.Height = adornedElement.DesiredSize.Height;
            }
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double desiredWidth = AdornedElement.DesiredSize.Width;
            double desiredHeight = AdornedElement.DesiredSize.Height;

            double adornerWidth = this.DesiredSize.Width;
            double adornerHeight = this.DesiredSize.Height;

            bottomRight.Arrange(new Rect(desiredWidth - adornerWidth / 2, desiredHeight - adornerHeight / 2, adornerWidth, adornerHeight));
            return finalSize;
        }
    }
}
