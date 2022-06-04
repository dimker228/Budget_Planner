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
    internal class CategoryToOperation : INotifyCollectionChanged
    {
        public long Id { get; set; }
        public long FkIdOperation { get; set; }
        public long FkIdCategory { get; set; }

        public CategoryToOperation(long Id_, long FkIdOperation_, long FkIdCategory_)
        {
            this.Id = Id_;
            this.FkIdOperation = FkIdOperation_;
            this.FkIdCategory = FkIdCategory_;
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
