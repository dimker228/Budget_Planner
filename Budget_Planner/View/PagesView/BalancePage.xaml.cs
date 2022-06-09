using System.Windows.Controls;
using Budget_Planner.ViewModel;

namespace Budget_Planner.View.PagesView
{
    /// <summary>
    /// Логика взаимодействия для BalancePage.xaml
    /// </summary>
    public partial class BalancePage : Page
    {
        public BalancePage()
        {
            InitializeComponent();
            DataContext = new BalanceViewModel();
        }
    }
}
