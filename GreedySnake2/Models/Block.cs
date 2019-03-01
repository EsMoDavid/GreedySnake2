using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GreedySnake.Models
{
    public class Block:BaseElementModel
    {
        public static readonly SolidColorBrush HeadBrush = new SolidColorBrush(Colors.Red);
        public static readonly SolidColorBrush DefaultBrush = new SolidColorBrush(Colors.Black);
        bool isHead;
        public bool IsHead
        {
            get
            {
                return this.isHead;
            }
            set
            {
                if (this.isHead != value)
                {
                    this.isHead = value;
                    this.Color = this.isHead ? HeadBrush : DefaultBrush;
                }
            }
        }
        public Block()
        {
            this.Color = DefaultBrush;
        }
    }
}
