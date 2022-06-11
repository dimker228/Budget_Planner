using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using Budget_Planner.Model;

namespace Budget_Planner.ViewModel
{
    internal class BalanceViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        private IEnumerable<Balances> _balances;

        public IEnumerable<Balances> Balances
        {
            get { return _balances; }
            set
            {
                _balances = value;
                OnPropertyChanged("Balances");
            }
        }
        public BalanceViewModel()
        {
            ListMethod();
        }

        /// <summary>
        /// Заполнение страницы баланса
        /// </summary>
        public void ListMethod()
        {
            db = new ApplicationContext();
            db.Balances.Load();
            Balances = db.Balances.Local.ToBindingList();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
