using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace GreedySnake.Models
{
    public class BaseElementModel : INotifyPropertyChanged
    {
        SolidColorBrush color;
        public SolidColorBrush Color
        {
            get { return this.color; }
            set
            {
                if (this.color != value)
                {
                    this.color = value;
                    this.InvokePropertyChanged();
                }
            }
        }
        private Position position;
        public Position Position
        {
            get
            {
                return this.position;
            }
            set
            {
                if (this.position.X != value.X || this.position.Y != value.Y)
                {
                    this.position = value;
                    this.InvokePropertyChanged();
                }
            }
        }
        protected void InvokePropertyChanged([CallerMemberName]string propertyName="")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
