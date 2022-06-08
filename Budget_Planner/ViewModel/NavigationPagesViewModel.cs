using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Budget_Planner.View.PagesView;

namespace Budget_Planner.ViewModel
{
    public class NavigationPagesViewModel : INotifyPropertyChanged
    {
        private Page _balancePage;
        private Page _newOperationPage;
        private Page _historyPage;
      

        private Page _currentPage;
        public Page CurrentPage
        {
            get
            {
                return _currentPage;

            }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        public NavigationPagesViewModel()
        {
            _newOperationPage = new NewOperationPage();
            _historyPage = new View.PagesView.HistoryPage();
            _balancePage = new BalancePage();
            CurrentPage = _historyPage;
            //CurrentPage = _addPageProfession;
        }
        public RelayCommand OpenAddPage
        {
            get
            {
                return new RelayCommand(async (obj) =>
                {
                    CurrentPage = _newOperationPage;
                });
            }
        }
        public RelayCommand OpenHistoryPage
        {
            get
            {
                return new RelayCommand(async (obj) =>
                {
                    CurrentPage = _historyPage;
                });
            }
        }
        public RelayCommand OpenBalancePage
        {
            get
            {
                return new RelayCommand(async (obj) =>
                {
                    CurrentPage = _balancePage;
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
