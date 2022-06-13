using System.Windows.Controls;
using Budget_Planner.ViewModel;

namespace Budget_Planner.View.PagesView
{
    /// <summary>
    /// Логика взаимодействия для NewOperationPage.xaml
    /// </summary>
    public partial class NewOperationPage : Page
    {
        public NewOperationPage()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
        }
        
    }
}
