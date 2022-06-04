using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Planner.Model
{
    internal class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<CategoryToOperation> CategoryToOperations { get; set; }
        public DbSet<CategoryToOperationType> CategoryToOperationTypes { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<OperationTypeToOperation> OperationTypeToOperations { get; set; }
    }
}
