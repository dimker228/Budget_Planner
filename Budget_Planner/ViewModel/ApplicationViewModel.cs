using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Budget_Planner.Class;
using Budget_Planner.Model;


namespace Budget_Planner.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        #region Lists
        
        private string _sum;
        private string _comment;
        private int _comboType, _comboCategories;
        private RelayCommand _nullCommand;
        private RelayCommand _loadComboCategories;
        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _editCommand;
        ApplicationContext db;
        IEnumerable<Balances> balances;
        IEnumerable<CategoriesToOperationTypes> categoriesToOperationsTypes;
        IEnumerable<Operations> operations;
        IEnumerable<OperationTypes> operationsTypes;
        IEnumerable<Categories> categories;
        public string Sum
        {
            get { return _sum; }
            set
            {
                _sum = value;
                OnPropertyChanged("Sum");
            }
        }
        
        public string Comment {
            get { return _comment; }
            set
            {
                _comment = value;
                OnPropertyChanged("Comment");
            }
        }
        public int ComboType {
            get { return _comboType; }
            set
            {
                _comboType = value;
                OnPropertyChanged("ComboType");
            }
        }
        public int ComboCategories {
            get { return _comboCategories; }
            set
            {
                _comboCategories = value;
                OnPropertyChanged("ComboCategories");
            }
        }
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
        public ApplicationViewModel()
        {
            db = new ApplicationContext();
            db.Categories.Load();
            db.OperationTypes.Load();
            Categories = db.Categories.ToList();
            OperationTypes = db.OperationTypes.ToList();
            NullCommand = new CommandClass();
            AddCommand = new AddCommand();

        }


        #region Command


        public ICommand AddCommand
        {
            get;

        }

        
        public ICommand NullCommand
        {
            get;
        }
       
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
