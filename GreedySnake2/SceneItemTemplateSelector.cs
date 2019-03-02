using GreedySnake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GreedySnake
{
    public class SceneItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HeadTemplate { get; set; }
        public DataTemplate BlockTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var block = item as Block;
            return block.IsHead ? this.HeadTemplate : this.BlockTemplate;
        }
    }
}
