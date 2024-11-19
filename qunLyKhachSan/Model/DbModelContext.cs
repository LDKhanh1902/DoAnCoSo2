using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
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

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Bill> Bills {  get; set; } 

        public DbSet<BillDetail> BillDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure relationships and constraints here if needed

            modelBuilder.Entity<Position>()
                .HasMany(p => p.PositionPermissions)
                .WithRequired(pp => pp.Position)
                .HasForeignKey(pp => pp.PositionID);

            modelBuilder.Entity<Permission>()
                .HasMany(p => p.PositionPermissions)
                .WithRequired(pp => pp.Permission)
                .HasForeignKey(pp => pp.PermissionID);

            modelBuilder.Entity<Customer>()
                .HasRequired(c => c.Country)
                .WithMany(c => c.Customers)
                .HasForeignKey(c => c.CountryID);

            modelBuilder.Entity<Customer>()
                .HasRequired(c => c.CustomerType)
                .WithMany(ct => ct.Customers)
                .HasForeignKey(c => c.CustomerTypeID);

            modelBuilder.Entity<Employee>()
                .HasRequired(e => e.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PositionID);

            modelBuilder.Entity<Room>()
                .HasRequired(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.TypeRoomID);

            modelBuilder.Entity<Bill>()
                .HasRequired(b => b.Room)
                .WithMany(r => r.Bills)
                .HasForeignKey(b => b.RoomID);

            modelBuilder.Entity<Bill>()
                .HasRequired(b => b.Employee)
                .WithMany(e => e.Bills)
                .HasForeignKey(b => b.EmployeeID);

            modelBuilder.Entity<Bill>()
                .HasRequired(b => b.Customer)
                .WithMany(c => c.Bills)
                .HasForeignKey(b => b.CustomerID);

            modelBuilder.Entity<BillDetail>()
                .HasRequired(bd => bd.Bill)
                .WithMany(b => b.BillDetails)
                .HasForeignKey(bd => bd.BillID);

            modelBuilder.Entity<BillDetail>()
                .HasRequired(bd => bd.Service)
                .WithMany(s => s.BillDetails)
                .HasForeignKey(bd => bd.ServiceID);
        }
    }
}
