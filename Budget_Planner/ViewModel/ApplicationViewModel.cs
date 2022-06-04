using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Budget_Planner.Model;

namespace Budget_Planner.ViewModel
{
    public class ApplicationViewModel : INotifyCollectionChanged
    {
        ApplicationContext db;
        IEnumerable<Categories> categories;
        public IEnumerable<Categories> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }
        public ApplicationViewModel()
        {
            db = new ApplicationContext();
            db.Categories.Load();
            Categories = db.Categories.Local.ToBindingList();
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
