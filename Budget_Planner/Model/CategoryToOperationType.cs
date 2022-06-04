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
    internal class CategoryToOperationType : INotifyPropertyChanged
    {
        public long Id { get; set; }
        public long FkIdOperationToType { get; set; }
        public long FkIdCatefory { get; set; }

        public CategoryToOperationType(long Id_, long FkIdOperationToType_, long FkIdCatefory_)
        {
            this.Id = Id_;
            this.FkIdOperationToType = FkIdOperationToType_;
            this.FkIdCatefory = FkIdCatefory_;
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
