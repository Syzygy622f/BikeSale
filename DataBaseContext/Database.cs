using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Microsoft.EntityFrameworkCore;


namespace DataBaseContext
{
    public class Database(DbContextOptions options) : DbContext(options)
    {

        public DbSet<Bike> bikes { get; set; }
        public DbSet<User> users { get; set; }
    }
}
