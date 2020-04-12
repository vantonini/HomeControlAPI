using Microsoft.EntityFrameworkCore;

namespace HomeControlDAL {
    public partial class HomeControlContext : DbContext {

        public HomeControlContext() {

        }
        public HomeControlContext(DbContextOptions<HomeControlContext> options)
            : base(options) {
        }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .HasColumnName("CategoryID");
        }
                

    }
}