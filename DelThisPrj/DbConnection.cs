
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Server=(localdb)\\mssqllocaldb;Database=testdb;Trusted_Connection=True
namespace DelThisPrj
{
    public class DbConnection :DbContext
    {
        public DbSet<Model> Model { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

    }

}
