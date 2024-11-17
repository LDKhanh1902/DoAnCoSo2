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

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Bill> Bills {  get; set; } 

        public DbSet<BillDetail> BillDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasRequired(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.TypeRoomID);
        }
    }
}
