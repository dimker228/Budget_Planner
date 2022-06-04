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
    internal class OperationTypesToOperations : INotifyPropertyChanged
    {
        public long Id { get; set; }
        public long FkIdTypeOperation { get; set; }
        public long FkIdOperation { get; set; }

        public OperationTypesToOperations(long Id_, long FkIdTypeOperation_, long FkIdOperation_)
        {
            this.Id = Id_;
            this.FkIdTypeOperation = FkIdTypeOperation_;
            this.FkIdOperation = FkIdOperation_;
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
