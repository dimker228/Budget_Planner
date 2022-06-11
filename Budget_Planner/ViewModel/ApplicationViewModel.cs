using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Budget_Planner.Class;
using Budget_Planner.Model;


namespace Budget_Planner.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        // Объявление модели и переменных для взаимодействия
        #region Lists
        
        private string _sum;
        private string _comment;
        private int _comboType, _comboCategories;
        ApplicationContext db;
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
        /// <summary>
        /// Заполнение вью страницы 
        /// </summary>
        public ApplicationViewModel()
        {
            db = new ApplicationContext();
            db.OperationTypes.Load();
            OperationTypes = db.OperationTypes.ToList();
            NullCommand = new CommandClass();
            AddCommand = new AddCommand();
        }

        //Объявление команд для работы с приложением
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
