using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GreedySnake.ViewModels
{
    public class DefaultCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action<object> onExecute;

        public DefaultCommand(Action<object> onExecute)
        {
            this.onExecute = onExecute;
        }
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public virtual void Execute(object parameter)
        {
            this.onExecute?.Invoke(parameter);
        }
    }
    public class ArrowKeyCommand : DefaultCommand
    {
        public ArrowKeyCommand(Action<object> onExecute):base(onExecute)
        {
         
        }

        public override bool CanExecute(object parameter)
        {
            Key key = (Key)Enum.Parse(typeof(Key), parameter.ToString());
            return key == Key.Up || key == Key.Down || key == Key.Left || key == Key.Right;
        }
    }
}
