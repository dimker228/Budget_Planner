using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Budget_Planner.Model;


namespace Budget_Planner.ViewModel
{
    public class ApplicationViewModel : INotifyCollectionChanged
    {
        #region Lists

        private string _sum, _comment;
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
        public string Sum { get;set; }
        
        public string Comment { get; set; }
        public int ComboType { get; set; }
        public int ComboCategories { get; set; }
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
            //db = new ApplicationContext();
            //var c = db.Categories;
            //var o = db.Operations;
            //var t = new OperationTypes();
            //db.Categories.Load();
            //db.OperationTypes.Load();
            //Categories = db.Categories.ToList();
            //OperationTypes = db.OperationTypes.ToList();
            var operationsQuery =
                from op in Operations
                join Type in OperationTypes on op.Type_Id equals Type.Id
                select new
                {
                    Sum = op.Sum,
                    TypeName = Type.TypeOperationName,
                    Comment = op.Comment,
                    Date = op.Date,
                    CategoriesId = op.Categories_Id
                
                };
            //// a property from each element.
            //var innerJoinQuery =
            //    from category in categories
            //    join prod in products on category.ID equals prod.CategoryID
            //    select new { Category = category.ID, Product = prod.Name };

        }

        #region Command


        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                       (_addCommand = new RelayCommand((o) =>
                       {
                           int num;
                           bool isNum = int.TryParse(Sum, out num);
                           if (isNum || ComboType != 0 || ComboCategories != 0) 
                           {
                               //var operations = new Operations();
                               //operations.Sum = Sum;
                               //operations.Type_Id = ComboType;
                               //operations.Comment = Comment;
                               //operations.Categories_Id = ComboCategories;
                               //operations.Date = DateTime.Now.ToString();
                               //operations.Categories = new List<Categories>();
                               //operations.Categories.AddRange(Categories);
                               //db.Operations.Add(operations);
                               db.SaveChanges();
                               //var balances = new Balances();
                               MessageBox.Show("Операция добавлена","Успешно");
                               //balances.Balance = Convert.ToString(Convert.ToInt32(balances.Balance) + Convert.ToInt32(operations.Sum));
                               //db.Balances.Add(balances);
                           }
                           else
                           {
                               MessageBox.Show("Проверьте корректность ввода", "Ошибка");
                           }

                       }));
            }
        }

        //public async void MessageMethod()
        //{
        //    //MessageDialog dialog = new MessageDialog("Проверьте заполненные данные");
        //    MessageBox dialog = new MessageBox();
        //    await dialog.ShowAsync();
        //}
        public RelayCommand LoadComboCategories
        {
            get
            {
                return _loadComboCategories ??
                       (_loadComboCategories = new RelayCommand((o) =>
                       {
                           db.Categories.Load();
                           if (ComboType == 1)
                           {
                               Categories = db.Categories.Local.Where(w => w.Id == ComboType).ToList();
                           }
                           else
                           {
                               Categories = db.Categories.Local.Where(w => w.Id == ComboType).ToList();
                           }
                       }));
            }
        }
        public RelayCommand NullCommand
        {
            get
            {
                return _nullCommand ??
                       (_nullCommand = new RelayCommand((o) =>
                       {
                           Sum = "";
                           ComboType = 0;
                           Comment = "";
                           ComboCategories = 0;
                       }));
            }
        }
        //// команда редактирования
        //public RelayCommand EditCommand
        //{
        //    get
        //    {
        //        return editCommand ??
        //          (editCommand = new RelayCommand((selectedItem) =>
        //          {
        //                 db.Operations.Entry(Some)
        //                 db.SaveChanges();
        //          
        //          }));
        //    }
        //}
        // команда удаления
        //public RelayCommand DeleteCommand
        //{
        //    get
        //    {
        //        return deleteCommand ??
        //          (deleteCommand = new RelayCommand((selectedItem) =>
        //          {
        //              db.Operations.Remove(Some.Id)
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
