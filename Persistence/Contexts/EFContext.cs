using RhayFernando.Models;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persistence.Contexts
{
    public class EFContext : DbContext
    {
        #region [ DbSet Properties ]

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        #endregion [ DbSet Properties ]


        #region [ Constructor ]

        public EFContext()
            : base("Asp_Net_MVC_CS")
        {
            var dbInit = new
                DropCreateDatabaseIfModelChanges<EFContext>();
            Database.SetInitializer<EFContext>(dbInit);
        }

        #endregion [ Constructor ]

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}