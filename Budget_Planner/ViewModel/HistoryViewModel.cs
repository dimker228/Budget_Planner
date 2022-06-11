using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using Budget_Planner.Model;

namespace Budget_Planner.ViewModel
{
    internal class HistoryViewModel : INotifyCollectionChanged
    {
        #region Lists

        private ObservableCollection<OperationInclude> _operationInclude;
        public ObservableCollection<OperationInclude> OperationInclude
        {
            get { return _operationInclude ?? (_operationInclude = new ObservableCollection<OperationInclude>()); }
            set
            {
                _operationInclude = value;
                OnPropertyChanged("OperationInclude");
            }
        }
        ApplicationContext db;
        #endregion
        public HistoryViewModel()
        {

            DisplayMethod();

        }

        /// <summary>
        /// Реализация вывода, замена методу include или запросу join, не получилось т.к. модель C# не хранит в себе ссылки на таблицы, хоть я и добавлял внешние ключи
        /// </summary>
        public void DisplayMethod()
        {
            OperationInclude.Clear();
            db = new ApplicationContext();
            foreach (var item in db.Operations)
            {
                var typename = db.OperationTypes.Where(i => i.Id == item.Type_Id).FirstOrDefault();
                var catname = db.Categories.Where(i => i.Id == item.Categories_Id).FirstOrDefault();
                OperationInclude.Add(new OperationInclude
                {
                    Sum = item.Sum,
                    TypeOperationName = typename.TypeOperationName,
                    Date = item.Date,
                    CategoryName = catname.CategoryName,
                    Comment = item.Comment
                });

            }

            OperationInclude.ToBindingList();
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
