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
        private RelayCommand editCommand;
        ApplicationContext db;
        IEnumerable<Balances> balances;
        IEnumerable<CategoriesToOperationTypes> categoriesToOperationsTypes;
        IEnumerable<Operations> operations;
        IEnumerable<OperationTypes> operationsTypes;
        IEnumerable<Categories> categories;
        public string Sum { get; set; }
        public string Comment { get; set; }
        public IEnumerable<Balances> Balances
        {
            get { return balances; }
            set
            {
                balances = value;
                OnPropertyChanged("Balances");
            }
        }

        public IEnumerable<CategoriesToOperationTypes> CategoriesToOperationTypes
        {
            get { return categoriesToOperationsTypes; }
            set
            {
                categoriesToOperationsTypes = value;
                OnPropertyChanged("CategoriesToOperationTypes");
            }
        }
        public IEnumerable<Operations> Operations
        {
            get { return operations; }
            set
            {
                operations = value;
                OnPropertyChanged("Operations");
            }
        }

        public IEnumerable<OperationTypes> OperationTypes
        {
            get { return operationsTypes; }
            set
            {
                operationsTypes = value;
                OnPropertyChanged("OperationTypes");
            }
        }
        public IEnumerable<Categories> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }
        #endregion
        public HistoryViewModel()
        {
            OperationTypes operationTypes = new OperationTypes();
            Categories categories = new Categories();
            db = new ApplicationContext();
            db.Operations.Load();
            Operations = db.Operations.ToList();


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
