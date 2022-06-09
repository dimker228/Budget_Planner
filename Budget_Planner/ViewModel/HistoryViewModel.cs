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
    internal class HistoryViewModel : INotifyCollectionChanged
    {
        #region Lists
        public List<OperationInclude> operationInclude { get; set; }
        private RelayCommand editCommand;
        ApplicationContext db;
        #endregion
        public HistoryViewModel()
        {
            // Реализация вывода, замена методу include или запросу join, не получилось т.к. модель C# не хранит в себе ссылки на таблицы, хоть я и добавлял внешние ключи
            db = new ApplicationContext();
            operationInclude = new List<OperationInclude>();
            foreach (var item in db.Operations)
            {
                var typename = db.OperationTypes.Where(i => i.Id == item.Type_Id).FirstOrDefault();
                var catname = db.Categories.Where(i => i.Id == item.Categories_Id).FirstOrDefault();
                operationInclude.Add(new OperationInclude
                {
                    Sum = item.Sum,
                    TypeOperationName = typename.TypeOperationName,
                    Date = item.Date,
                    CategoryName = catname.CategoryName,
                    Comment = item.Comment
                });
                
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
