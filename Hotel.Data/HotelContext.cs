using Hotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext() : base("HotelContext")
        {

        }
        public DbSet<TempModel> TempUser { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoleInfo> UserRoleInfo { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}
