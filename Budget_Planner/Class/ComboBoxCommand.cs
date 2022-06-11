using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Budget_Planner.Model;
using Budget_Planner.ViewModel;

namespace Budget_Planner.Class
{
    internal class ComboBoxCommand : ICommand
    {
     
        private ApplicationContext db;
        public IEnumerable<OperationTypes> OperationTypes { get; set; }
       
        public IEnumerable<Categories> Categories { get; set; }
      
        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {
            if (parameter is ApplicationViewModel applicationViewModel)
            {
              
                if(applicationViewModel.ComboType == 1)
                {
                    db = new ApplicationContext();
                    db.Categories.Load();
                    db.OperationTypes.Load();
                    Categories = db.Categories.ToList();
                    OperationTypes = db.OperationTypes.ToList();
                }
             
            }

        }

        public event EventHandler CanExecuteChanged;

    
    }
}
