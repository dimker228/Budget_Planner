using System;
using System.Windows.Controls;
using System.Windows.Input;
using Budget_Planner.View.PagesView;
using Budget_Planner.ViewModel;

namespace Budget_Planner.Class
{
    //Команда открытия страницы добавления операции
    internal class OpenAddPageCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }
        private Page _newOperationPage;
        public void Execute(object parameter)
        {
            if (parameter is NavigationPagesViewModel navigationPagesViewModel)
            {
                _newOperationPage = new NewOperationPage();
                navigationPagesViewModel.CurrentPage = _newOperationPage;
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
