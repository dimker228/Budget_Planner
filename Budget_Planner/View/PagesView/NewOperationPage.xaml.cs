using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;
using Budget_Planner.Model;
using Budget_Planner.ViewModel;

namespace Budget_Planner.View.PagesView
{
    /// <summary>
    /// Логика взаимодействия для NewOperationPage.xaml
    /// </summary>
    public partial class NewOperationPage : Page
    {
        IEnumerable<OperationTypes> OperationsTypes;
        IEnumerable<Categories> Categories;
        private ApplicationContext db;
        public NewOperationPage()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
        }
        /// <summary>
        /// Событие для заполнения категорий при выборе типа операции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeCombo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            db = new ApplicationContext();
            db.OperationTypes.Load();
            if (Convert.ToInt32(TypeCombo.SelectedValue) == 1)
            {
                CategoriesCombo.ItemsSource = db.Categories.Where(i => i.Id <= 4).ToList();
            }
            else
            {
                CategoriesCombo.ItemsSource = db.Categories.Where(i => i.Id >= 5).ToList();
            }
        }
    }
}
