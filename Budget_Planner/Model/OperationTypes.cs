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
    public class OperationTypes : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _typeOperationName;

        public string TypeOperationName
        {
            get { return _typeOperationName;}
             set
             {
                _typeOperationName = value; 
                 OnPropertyChanged("TypeOperationName");
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
