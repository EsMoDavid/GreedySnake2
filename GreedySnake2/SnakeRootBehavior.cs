using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace GreedySnake
{
    public class RootGridBehavior:Behavior<Grid>
    {
        public int RowsCount
        {
            get { return (int)GetValue(RowsCountProperty); }
            set { SetValue(RowsCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RowCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RowsCountProperty =
            DependencyProperty.Register("RowsCount", typeof(int), typeof(RootGridBehavior), new PropertyMetadata(0));


        public int ColumnsCount
        {
            get { return (int)GetValue(ColumnsCountProperty); }
            set { SetValue(ColumnsCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ColumnsCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColumnsCountProperty =
            DependencyProperty.Register("ColumnsCount", typeof(int), typeof(RootGridBehavior), new PropertyMetadata(0));

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.RowDefinitions.Clear();
            this.AssociatedObject.ColumnDefinitions.Clear();
            for (int i = 0; i < this.ColumnsCount; i++)
            {
                this.AssociatedObject.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            }
            for (int i = 0; i < this.RowsCount; i++)
            {
                this.AssociatedObject.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            }
        }
    }
}
