using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Work_with_API.Command
{
    class GetCommand : ICommand
    {
        ApiVM VM { get; set; }
        public GetCommand(ApiVM vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return !String.IsNullOrEmpty(parameter as string);
        }

        public void Execute(object parameter)
        {
            VM.MakeRequestStudents();
        }
    }
}
