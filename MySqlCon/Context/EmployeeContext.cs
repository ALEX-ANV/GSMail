using System.Data.Common;
using System.Data.Entity;
using MySqlCon.Model;

namespace MySqlCon.Context
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeeContext() : base("EmployeeContext")
        {

        }

        // Constructor to use on a DbConnection that is already opened
        public EmployeeContext(DbConnection existingConnection, bool contextOwnsConnection)
      : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().MapToStoredProcedures();
        }

    }
}
