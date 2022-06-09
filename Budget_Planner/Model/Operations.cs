using System;
using System.Collections.Specialized;
using System.ComponentModel;

using System.Runtime.CompilerServices;


namespace Budget_Planner.Model
{
    public class Operations : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private DateTime _date;
        private string _sum;
        private string _comment;
        public int Categories_Id { get; set; }
        public int Type_Id { get; set; }

        //public Categories Categories { get; set; }
        //public OperationTypes OperationTypes { get; set; }

        public string Sum
        {
            get { return _sum; }
            set
            {
                _sum = value;
                OnPropertyChanged("Sum");
            }
        }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                OnPropertyChanged("Comment");
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
