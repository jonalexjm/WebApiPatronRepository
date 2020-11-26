using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Northwind.Api.Models;

#nullable disable

namespace Northwind.Api.Repository.Mysql
{
    public partial class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext()
        {
        }

        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderitem> Orderitems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => new { e.LastName, e.FirstName }, "IndexCustomerName");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.City)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("city")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Country)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("country")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(40)")
                    .HasColumnName("first_name")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(40)")
                    .HasColumnName("last_name")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Phone)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("phone")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasIndex(e => e.CustomerId, "IndexOrderCustomerId");

                entity.HasIndex(e => e.OrderDate, "IndexOrderOrderDate");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("order_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.OrderNumber)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("order_number")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.TotalAmount)
                    .HasPrecision(12, 2)
                    .HasColumnName("total_amount")
                    .HasDefaultValueSql("'0.00'");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<Orderitem>(entity =>
            {
                entity.ToTable("orderitem");

                entity.HasIndex(e => e.OrderId, "IndexOrderItemOrderId");

                entity.HasIndex(e => e.ProductId, "IndexOrderItemProductId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.OrderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("order_id");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_id");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UnitPrice)
                    .HasPrecision(12, 2)
                    .HasColumnName("unit_price");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERITE_REFERENCE_ORDER");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERITE_REFERENCE_PRODUCT");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.ProductName, "IndexProductName");

                entity.HasIndex(e => e.SupplierId, "IndexProductSupplierId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IsDiscontinued).HasColumnName("is_discontinued");

                entity.Property(e => e.Package)
                    .HasColumnType("varchar(30)")
                    .HasColumnName("package")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("product_name")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.SupplierId)
                    .HasColumnType("int(11)")
                    .HasColumnName("supplier_id");

                entity.Property(e => e.UnitPrice)
                    .HasPrecision(12, 2)
                    .HasColumnName("unit_price")
                    .HasDefaultValueSql("'0.00'");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_REFERENCE_SUPPLIER");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("supplier");

                entity.HasIndex(e => e.Country, "IndexSupplierCountry");

                entity.HasIndex(e => e.CompanyName, "IndexSupplierName");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.City)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("city")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("varchar(40)")
                    .HasColumnName("company_name")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ContactName)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("contact_name")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ContactTitle)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("contact_title")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Country)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("country")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Fax)
                    .HasColumnType("varchar(30)")
                    .HasColumnName("fax")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Phone)
                    .HasColumnType("varchar(30)")
                    .HasColumnName("phone")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
