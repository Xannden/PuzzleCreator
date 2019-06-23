using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PuzzleCreator.View
{
    public class Board : Control
    {
        private VisualCollection visualCollection;

        static Board()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(Board), new FrameworkPropertyMetadata(typeof(Board)));
        }

        public Board()
        {
            this.visualCollection = new VisualCollection(null);

            this.visualCollection.Add(new Rectangle()
            {
                Fill = Brushes.Black,
            });
        }

        protected override int VisualChildrenCount => this.visualCollection.Count;

        protected override Size ArrangeOverride(Size arrangeBounds) => base.ArrangeOverride(arrangeBounds);

        protected override Visual GetVisualChild(int index) => this.visualCollection[index];

        protected override Size MeasureOverride(Size constraint) => base.MeasureOverride(constraint);
    }
}