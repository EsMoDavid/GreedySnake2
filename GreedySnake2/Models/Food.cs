using System.Windows.Media;

namespace GreedySnake.Models
{
    public class Food :BaseElementModel
    {
        public Food()
        {
            this.Color = new SolidColorBrush(Colors.Green);
        }
    }
}
