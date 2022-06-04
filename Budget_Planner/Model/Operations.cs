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
    internal class Operations : INotifyPropertyChanged
    {
        public long Id { get; set; }
        public string Sum { get; set; }
        public string Comment { get; set; }

        public Operations(long Id_, string Sum_, string Comment_)
        {
            this.Id = Id_;
            this.Sum = Sum_;
            this.Comment = Comment_;
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
