using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Budget_Planner.ViewModel;

namespace Budget_Planner.Class
{
    internal class CommandClass : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {
            if (parameter is ApplicationViewModel applicationViewModel)
            {
                applicationViewModel.Sum = String.Empty;
                applicationViewModel.ComboType = 0;
                applicationViewModel.Comment = String.Empty;
                applicationViewModel.ComboCategories = 0;
            }
            
        }

        public event EventHandler CanExecuteChanged;
    }
}
