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
                InsertMethod(applicationViewModel.Sum, applicationViewModel.ComboType, applicationViewModel.Comment, applicationViewModel.ComboCategories);
            }

        }

        public void InsertMethod(string sum, int comboType, string comment , int comboCategories)
        {
            db = new ApplicationContext();
            HistoryViewModel historyViewModel = new HistoryViewModel();
            BalanceViewModel balanceView = new BalanceViewModel();
            double num;
            bool isNum = double.TryParse(sum, out num);
            if (isNum && comboType != 0 && comboCategories != 0)
            {
                var operations = new Operations();
                var balances1 = new Balances();
                balances1.Id = 1;
                var balances = db.Balances.Find(balances1.Id);
                operations.Sum = sum;
                operations.Type_Id = comboType;
                operations.Comment = comment;
                operations.Categories_Id = comboCategories;
                operations.Date = DateTime.Now;
                db.Operations.Add(operations);
                db.SaveChanges();
                db.Entry(operations).State = EntityState.Detached;
                if (comboType == 1 || Convert.ToInt32(sum) <= 0)
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

        public event EventHandler CanExecuteChanged;

    }
}
