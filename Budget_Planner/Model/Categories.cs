using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Budget_Planner.Model
{
    public class Categories : INotifyPropertyChanged
    {

        public int Id { get; set; }


        private string _categoryName;

        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                _categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }

        //public List<Operations> Operations { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
