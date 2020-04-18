using Microsoft.EntityFrameworkCore;

namespace HomeControlDAL {
    public partial class HomeControlContext : DbContext {
        
      

        public HomeControlContext() : base() {
            
        }
        public HomeControlContext(DbContextOptions<HomeControlContext> options)
            : base(options) {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .HasColumnName("CategoryID");

            modelBuilder.Entity<Store>()
                .Property(c => c.Id)
                .HasColumnName("StoreID");

            modelBuilder.Entity<Store>(entity => {
                entity.HasIndex(e => e.StoreOriginalName).IsUnique();
            });
                

            modelBuilder.Entity<Transaction>()
                .Property(c => c.Id)
            .HasColumnName("TransactionID");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source=MSI\\Testserver;Initial Catalog=HomeControl;Integrated Security=True");

        }

    }
}