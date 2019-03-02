using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GreedySnake.ViewModels
{
    public class ArrowKeyCommand : ICommand
    {
        Action<object> onExecute;
        public event EventHandler CanExecuteChanged;


        public ArrowKeyCommand(Action<object> onExecute)
        {
            this.onExecute = onExecute;
        }

        public bool CanExecute(object parameter)
        {
            Key key = (Key)Enum.Parse(typeof(Key), parameter.ToString());
            return key == Key.Up || key == Key.Down || key == Key.Left || key == Key.Right;
        }

        public void Execute(object parameter)
        {
            this.onExecute?.Invoke(parameter);
        }
    }
}
