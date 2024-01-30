using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_29_01
{
    internal class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LIBERTY; Database=DZ_29_01; Trusted_Connection=True; TrustServerCertificate=True; Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
