using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Budget_Planner.View.PagesView;

namespace Budget_Planner.ViewModel
{
    internal class NavigationPagesViewModel
    {
        private HistoryPage _historyPage;
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
            _historyPage = new HistoryPage();
            CurrentPage = _historyPage;
            //CurrentPage = _addPageProfession;
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
