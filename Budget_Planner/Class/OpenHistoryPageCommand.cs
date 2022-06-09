using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Budget_Planner.View.PagesView;
using Budget_Planner.ViewModel;

namespace Budget_Planner.Class
{
    internal class OpenHistoryPageCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

      
        private Page _historyPage;

        public void Execute(object parameter)
        {
            if (parameter is NavigationPagesViewModel navigationPagesViewModel)
            {
                _historyPage = new HistoryPage();
                navigationPagesViewModel.CurrentPage = _historyPage;
            }

        }

        public event EventHandler CanExecuteChanged;
    }
}
