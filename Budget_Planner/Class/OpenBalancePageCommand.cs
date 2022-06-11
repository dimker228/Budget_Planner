using System;
using System.Windows.Controls;
using System.Windows.Input;
using Budget_Planner.View.PagesView;
using Budget_Planner.ViewModel;

namespace Budget_Planner.Class
{
    //Команда открытия страницы баланса

    internal class OpenBalancePageCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        private Page _balancePage;
     

        public void Execute(object parameter)
        {
            if (parameter is NavigationPagesViewModel navigationPagesViewModel)
            {
                _balancePage = new BalancePage();
                navigationPagesViewModel.CurrentPage = _balancePage;
            }

        }

        public event EventHandler CanExecuteChanged;
    }
}
