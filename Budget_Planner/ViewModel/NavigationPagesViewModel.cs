using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using Budget_Planner.Class;

namespace Budget_Planner.ViewModel
{
    public class NavigationPagesViewModel : INotifyPropertyChanged
    {
    
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
        /// <summary>
        /// Датаконтекст для навигации
        /// </summary>
        public NavigationPagesViewModel()
        {
            _historyPage = new View.PagesView.HistoryPage();
            CurrentPage = _historyPage;
            OpenAddPage = new OpenAddPageCommand();
            OpenHistoryPage = new OpenHistoryPageCommand();
            OpenBalancePage = new OpenBalancePageCommand();
        }
        public ICommand OpenAddPage
        {
            get;

        }
        public ICommand OpenHistoryPage
        {
            get;

        }
        public ICommand OpenBalancePage
        {
            get;

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
