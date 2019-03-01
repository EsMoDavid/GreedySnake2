using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GreedySnake.Views
{
    public class GridLinePanel : Canvas
    {
        Pen gridlinePen;
        public GridLinePanel()
        {
            this.gridlinePen = new Pen(new SolidColorBrush(Colors.Gray), 2);
        }
        public int RowsCount
        {
            get { return (int)GetValue(RowsCountProperty); }
            set { SetValue(RowsCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RowCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RowsCountProperty =
            DependencyProperty.Register("RowsCount", typeof(int), typeof(GridLinePanel), new PropertyMetadata(0));

        public int ColumnsCount
        {
            get { return (int)GetValue(ColumnsCountProperty); }
            set { SetValue(ColumnsCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ColumnsCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColumnsCountProperty =
            DependencyProperty.Register("ColumnsCount", typeof(int), typeof(GridLinePanel), new PropertyMetadata(0));
        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            int colCount = this.ColumnsCount;
            int rowCount = this.RowsCount;
            double width = this.ActualWidth;
            double height = this.ActualHeight;
            double horizontalSpan = width / colCount;
            double verticalSpan = height / rowCount;
            for (int i = 1; i < colCount; i++)
            {
                dc.DrawLine(this.gridlinePen, new Point(i * horizontalSpan, 0), new Point(i * horizontalSpan, height));
            }
            for (int i = 0; i < rowCount; i++)
            {
                dc.DrawLine(this.gridlinePen, new Point(0, i * verticalSpan), new Point(width, i * verticalSpan));
            }
        }
    }
}
