using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qunLyKhachSan.Model
{
    internal class DbModelContext : DbContext
    {
        public DbModelContext() :base("Db_QuanLyKhachSan") { }
    
        public DbSet<Position> Positions { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Position_Permissions> Position_Permissions { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<CustomerType> CustomerTypes { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}
