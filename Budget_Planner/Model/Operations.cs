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
    public class Operations : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _sum;
        private string _comment;

        public string Sum
        {
            get { return _sum; }
            set
            {
                _sum = value; 
                OnPropertyChanged("Sum");
            }
        }

        public string Comment
        {
            get{return _comment}
            set
            {
                _comment=value;
                OnPropertyChanged("comment");
            }
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
