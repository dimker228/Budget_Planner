using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Budget_Planner.Model
{
    public class CategoriesToOperationTypes : INotifyCollectionChanged
    {
        public int Id { get; set; }
        public int FkIdOperationToType { get; set; }
        public int FkIdCategory { get; set; }
        public virtual OperationTypes OperationTypes { get; set; }
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
