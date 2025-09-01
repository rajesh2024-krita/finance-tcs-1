
using Microsoft.EntityFrameworkCore;
using FintcsApi.Models;

namespace FintcsApi.Data
{
    public class FintcsDbContext : DbContext
    {
        public FintcsDbContext(DbContextOptions<FintcsDbContext> options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Society> Societies { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<SocietyApproval> SocietyApprovals { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // User entity configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("datetime('now')");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("datetime('now')");
            });
            
            // Society entity configuration
            modelBuilder.Entity<Society>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("datetime('now')");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("datetime('now')");
            });
            
            // Member entity configuration
            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.MemNo).IsUnique();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("datetime('now')");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("datetime('now')");
            });
            
            // SocietyApproval entity configuration
            modelBuilder.Entity<SocietyApproval>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserId);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("datetime('now')");
            });
        }
    }
}
