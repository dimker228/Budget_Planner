using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Planner.Model
{
    internal class Balances : INotifyCollectionChanged
    {
        public long Id { get; set; }
        public string Balance { get; set; }
        public string BalanceType { get; set; }

        public Balances(long Id_, string Balances_, string BalanceType_)
        {
            this.Id = Id_;
            this.Balance = Balances_;
            this.BalanceType = BalanceType_;
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
