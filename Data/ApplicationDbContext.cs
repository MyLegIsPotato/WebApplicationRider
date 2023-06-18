using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using WebApplicationRider.Models;

namespace WebApplicationRider.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<BlogPost> BlogPosts { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<Category>().ToTable("Category");
        modelBuilder.Entity<BlogPost>().ToTable("BlogPost");
        modelBuilder.Entity<BlogPost>()
            .HasOne(bp => bp.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
