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
    internal class OperationTypes : INotifyPropertyChanged
    {
        public long Id { get; set; }
        public string TypeOperationName { get; set; }

        public OperationTypes(long Id_, string TypeOperationName_)
        {
            this.Id = Id_;
            this.TypeOperationName = TypeOperationName_;
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
