using System;
using System.Data.Entity;
using System.Windows;
using System.Windows.Input;
using Budget_Planner.Model;
using Budget_Planner.ViewModel;

namespace Budget_Planner.Class
{
    //Команда добавления новой операции
    internal class AddCommand : ICommand
    {


        public bool CanExecute(object parameter)
        {
            return true;
        }

        private ApplicationContext db;
        public void Execute(object parameter)
        {
            if (parameter is ApplicationViewModel applicationViewModel)
            {
                db = new ApplicationContext();
                HistoryViewModel historyViewModel = new HistoryViewModel();
                BalanceViewModel balanceView = new BalanceViewModel();
                double num;
                bool isNum = double.TryParse(applicationViewModel.Sum, out num);
                if (isNum && applicationViewModel.ComboType != 0 && applicationViewModel.ComboCategories != 0)
                {
                    var operations = new Operations();
                    var b = new Balances();
                    b.Id = 1;
                    var balances = db.Balances.Find(b.Id);
                    operations.Sum = applicationViewModel.Sum;
                    operations.Type_Id = applicationViewModel.ComboType;
                    operations.Comment = applicationViewModel.Comment;
                    operations.Categories_Id = applicationViewModel.ComboCategories;
                    operations.Date = DateTime.Now;
                    db.Operations.Add(operations);
                    db.SaveChanges();
                    db.Entry(operations).State = EntityState.Detached;
                    if (applicationViewModel.ComboType == 1)
                    {
                        balances.Balance =
                            Convert.ToString(Convert.ToDouble(operations.Sum) + Convert.ToDouble(balances.Balance));
                    }
                    else
                    {
                        balances.Balance =
                            Convert.ToString(Convert.ToDouble(balances.Balance) - Convert.ToDouble(operations.Sum));
                       
                    }
                    db.Entry(balances).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Операция добавлена", "Успешно");
                    historyViewModel.DisplayMethod();
                    balanceView.ListMethod();
                }
                else
                {
                             MessageBox.Show("Проверьте корректность ввода", "Ошибка");
                }

            }

        }


        public event EventHandler CanExecuteChanged;

    }
}
