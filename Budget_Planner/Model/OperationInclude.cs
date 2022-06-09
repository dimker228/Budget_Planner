using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Budget_Planner.Model
{
    public class OperationInclude : INotifyCollectionChanged
    {
        private object _sum;
        private object _typeOperationName;
        private object _date;
        private object _categoryName;
        private object _comment;
        public object Sum
        {
            get { return _sum; }
            set
            {
                _sum = value;
                OnPropertyChanged("Sum");
            }
        }
        public object TypeOperationName {
            get { return _typeOperationName; }
            set
            {
                _typeOperationName = value;
                OnPropertyChanged("TypeOperationName");
            }
        }
        public object Date {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }
        public object CategoryName
        {
            get { return _categoryName; }
            set
            {
                _categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }
        public object Comment {
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
