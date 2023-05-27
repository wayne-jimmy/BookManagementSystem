using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BMS.Entity.DataContext
{
    public partial class BMSDataContext : DbContext
    {
        public BMSDataContext()
            : base("name=BMSDataContext")
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
