using DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class ApplicationContext: DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(entity => new { entity.Id });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(key => new { key.Id });

                entity.HasIndex(index => index.Code)
                    .IsUnique();

            });


            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(key => new { key.Id });

                entity.Property(prop => prop.Created)
                   .HasDefaultValueSql("getdate()");

                entity.HasOne<Customer>(table => table.Customer)
                     .WithMany(detail => detail.Invoices)
                     .HasForeignKey(fkey => fkey.CustomerId);
            });


            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.HasKey(key => new { key.Noline, key.InvoiceId });

                entity.HasOne<Invoice>(table => table.Invoice)
                       .WithMany(detail => detail.InvoiceDetails)
                       .HasForeignKey(fkey => fkey.InvoiceId);

                entity.HasOne<Item>(table => table.Item)
                        .WithMany(detail => detail.InvoiceDetails)
                       .HasForeignKey(fkey => fkey.ItemId);
            });

        }
    }
}