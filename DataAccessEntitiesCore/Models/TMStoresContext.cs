using System;
using EntitiesCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EntitiesCore
{
    public partial class TMStoresContext : DbContext
    {
        public TMStoresContext()
        {
        }

        public TMStoresContext(DbContextOptions<TMStoresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=TMStores;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasComment("");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID")
                    .HasComment("The ID of the product.");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .HasComment("The product code that can be used to quicly access the product.");

                entity.Property(e => e.Description).HasComment("The product full description and specifications.");

                entity.Property(e => e.Image)
                    .HasColumnType("image")
                    .HasComment("The product image.");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .HasComment("The model or part number of the product.");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasComment("The name of the product.");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
