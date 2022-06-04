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
    public class Categories : INotifyPropertyChanged
    {
  //      public Category()
  //      {

  //      }
		//public long Id { get; set; }
        

  //      private string _CategoryName;
  //      public string CategoryName
  //      {
  //          get { return _CategoryName; }
  //          set { _CategoryName = value; }
  //      }

        public int Id { get; set; }
        //public string CategoryName { get; set; }

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
        //public Category(string CategoryName_)
        //{
        //    this.CategoryName = CategoryName_;
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
