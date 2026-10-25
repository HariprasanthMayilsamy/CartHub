using CartHubData.CartHubUserModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartHubData.DBContext
{
    public class CartHubDBContext:DbContext
    {
        public CartHubDBContext(DbContextOptions<CartHubDBContext> options) : base(options)
        {

        }
        public DbSet<User> T_User { get; set; }
        public DbSet<Country> T_Country { get; set; }
        public DbSet<State> T_State { get; set; }
        public DbSet<City> T_City { get; set; }
    }
}
