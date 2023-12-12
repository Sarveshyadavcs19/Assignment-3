using Assignment_3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Assignment_3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        
        //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        //{
        //    public ApplicationDbContext CreateDbContext(string[] args)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json")
        //            .Build();

        //        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //        var connectionString = configuration.GetConnectionString("myconnection"); 

        //        return new ApplicationDbContext(builder.Options);
        //    }
        //}
    



        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmpSalary> EmpSalaries { get; set; }

        
    }
}
