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
    public class CategoriesToOperation : INotifyCollectionChanged
    {
        public long Id { get; set; }
        public long FkIdOperation { get; set; }
        public long FkIdCategory { get; set; }

       public virtual Operations Operations { get; set; }
       public virtual Categories Categories { get; set; }

       public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
