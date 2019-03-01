using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GreedySnake.Controls
{
    [TemplatePart(Name = "FoodPanel", Type = typeof(Grid))]
    public class SnakeControl : ItemsControl
    {
        Grid foodPanel;
        UIElement food;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.foodPanel = this.GetTemplateChild("FoodPanel") as Grid;
            this.food = this.GetTemplateChild("Food") as UIElement;
        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is SnakeControl;
        }
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
        }
    }
}
