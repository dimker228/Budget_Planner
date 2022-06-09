using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Budget_Planner.Model;

namespace Budget_Planner.ViewModel
{
    internal class BalanceViewModel : INotifyCollectionChanged
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
