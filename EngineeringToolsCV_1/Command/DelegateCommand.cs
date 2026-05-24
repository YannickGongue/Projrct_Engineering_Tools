using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.Command
{
    class DelegateCommand : ViewModelCommand
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _execute;

        public  DelegateCommand( Action<object> execute,
                               Func<object,bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public override void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}

