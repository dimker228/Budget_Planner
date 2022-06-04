using System.Data.Entity;


namespace Budget_Planner.Model
{
    internal class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }
        public DbSet<Balances> Balances { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<CategoriesToOperation> CategoryToOperations { get; set; }
        public DbSet<CategoriesToOperationTypes> CategoryToOperationTypes { get; set; }
        public DbSet<Operations> Operations { get; set; }
        public DbSet<OperationTypes> OperationTypes { get; set; }
        public DbSet<OperationTypesToOperations> OperationTypeToOperations { get; set; }
    }
}
