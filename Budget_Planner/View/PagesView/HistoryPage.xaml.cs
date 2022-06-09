using System.Windows.Controls;
using Budget_Planner.ViewModel;

namespace Budget_Planner.View.PagesView
{
    /// <summary>
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        public HistoryPage()
        {
            InitializeComponent();
            DataContext = new HistoryViewModel();
        }
    }
}
