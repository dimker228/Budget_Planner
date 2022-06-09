using System.Windows;
using Budget_Planner.ViewModel;

namespace Budget_Planner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new NavigationPagesViewModel();
        }
    }
}
