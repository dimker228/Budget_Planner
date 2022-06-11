using System.Windows.Controls;
using Budget_Planner.ViewModel;

namespace Budget_Planner.View.PagesView
{
    public partial class HistoryPage : Page
    {
        public HistoryPage()
        {
            InitializeComponent();
            DataContext = new HistoryViewModel();
        }
    }
}
