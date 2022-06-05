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
        #region Lists

        private RelayCommand addCommand;
        private RelayCommand deleteCommand;
        private RelayCommand editCommand;
        ApplicationContext db;
        IEnumerable<Balances> balances;
        IEnumerable<CategoriesToOperation> categoriesToOperations;
        IEnumerable<CategoriesToOperationTypes> categoriesToOperationsTypes;
        IEnumerable<Operations> operations;
        IEnumerable<OperationTypesToOperations> operationsTypesToOperations;
        IEnumerable<OperationTypes> operationsTypes;
        IEnumerable<Categories> categories;
        public IEnumerable<Balances> Balances
        {
            get { return balances; }
            set
            {
                balances = value;
                OnPropertyChanged("Balances");
            }
        }
        public IEnumerable<CategoriesToOperation> CategoriesToOperations
        {
            get { return categoriesToOperations; }
            set
            {
                categoriesToOperations = value;
                OnPropertyChanged("CategoriesToOperations");
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
        public IEnumerable<OperationTypesToOperations> OperationTypesToOperations
        {
            get { return operationsTypesToOperations; }
            set
            {
                operationsTypesToOperations = value;
                OnPropertyChanged("OperationTypesToOperations");
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
            Categories = db.Categories.Local.ToBindingList();
        }

        #region Command

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                       (addCommand = new RelayCommand((o) =>
                       {
                           var employee = new Employee();
                           employee.FirstName = FirstName;
                           employee.LastName = LastName;
                           employee.MiddleName = MiddleName;
                           employee.BirthDay = BirthDay;
                           db.Employee.Add(employee);
                           db.SaveChanges();
                       //NavigationPagesViewModel navigationPagesView = new NavigationPagesViewModel();
                       //_addPageProfession = new AddPageProfession();
                       //navigationPagesView.CurrentPage = _addPageProfession;

                       }));
            }
        }
        // команда редактирования
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((o) =>
                  {


                      var employee = new Employee();

                  //// получаем измененный объект
                      employee = db.Employee.Find(employee.Id);
                      if (employee != null)
                      {
                          employee = new Employee();
                          employee.FirstName = FirstName;
                          employee.LastName = LastName;
                          employee.MiddleName = MiddleName;
                          employee.BirthDay = BirthDay;
                          db.Entry(employee).State = EntityState.Modified;
                          db.SaveChanges();
                      }
                  }));
            }
        }
        // команда удаления
        //public RelayCommand DeleteCommand
        //{
        //    get
        //    {
        //        return deleteCommand ??
        //          (deleteCommand = new RelayCommand((selectedItem) =>
        //          {
        //              Employee employee = selectedItem as Employee;

        //              Employee vm = new Employee()
        //              {
        //                  Id = employee.Id,
        //                  FirstName = employee.FirstName,
        //                  LastName = employee.LastName,
        //                  MiddleName = employee.MiddleName,
        //                  BirthDay = employee.BirthDay
        //              };
        //              EmployeeWindow employeeWindow = new EmployeeWindow(vm);

        //              if (selectedItem == null) return;
        //              // получаем выделенный объект

        //              employee = db.Employee.Find(employeeWindow.Employee.Id);
        //              db.Employee.Remove(employee);
        //              db.SaveChanges();
        //          }));
        //    }
        //}

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
