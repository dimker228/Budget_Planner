using System;
using System.Data.Entity;
using System.Windows;
using System.Windows.Input;
using Budget_Planner.Model;
using Budget_Planner.ViewModel;

namespace Budget_Planner.Class
{
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
                HistoryViewModel hv = new HistoryViewModel();
                int num;
                bool isNum = int.TryParse(applicationViewModel.Sum, out num);
                if (isNum && applicationViewModel.ComboType != 0 && applicationViewModel.ComboCategories != 0)
                {
                    if (applicationViewModel.ComboType == 1)
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
                        balances.Balance =
                            Convert.ToString(Convert.ToDouble(operations.Sum) + Convert.ToDouble(balances.Balance));
                        db.Entry(balances).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
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
                        balances.Balance =
                            Convert.ToString(Convert.ToDouble(balances.Balance)-Convert.ToDouble(operations.Sum));
                        db.Entry(balances).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    MessageBox.Show("Операция добавлена", "Успешно");
                    hv.DisplayMethod();
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
