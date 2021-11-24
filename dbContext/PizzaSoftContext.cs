using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SoftPizzaHut
{
    public partial class PizzaSoftContext : DbContext
    {
        public PizzaSoftContext()
        {
            Database.EnsureCreated();
        }

        public PizzaSoftContext(DbContextOptions<PizzaSoftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<Purchase> Purchases { get; set; } = null!;
        public virtual DbSet<RelationPc> RelationPcs { get; set; } = null!;
        public virtual DbSet<Сategory> Сategories { get; set; } = null!;

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              //optionsBuilder.UseSqlServer("Server=DESKTOP-DTUTPCE\\SQLEXPRESS;Database=PizzaSoft;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PizzaSoft;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.IdProviderProduct).HasColumnName("id_provider_product");

                entity.Property(e => e.NameProduct)
                    .HasMaxLength(150)
                    .HasColumnName("name_product");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Unit)
                    .HasMaxLength(45)
                    .HasColumnName("unit");

                entity.HasOne(d => d.IdProviderProductNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdProviderProduct)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Products_Providers");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.IdProvider);

                entity.Property(e => e.IdProvider).HasColumnName("id_provider");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.Inn)
                    .HasMaxLength(45)
                    .HasColumnName("inn");

                entity.Property(e => e.Kpp)
                    .HasMaxLength(45)
                    .HasColumnName("kpp");

                entity.Property(e => e.NameProvider)
                    .HasMaxLength(250)
                    .HasColumnName("name_provider");

                entity.Property(e => e.Ogrn)
                    .HasMaxLength(45)
                    .HasColumnName("ogrn");

                entity.Property(e => e.Registration)
                    .HasMaxLength(200)
                    .HasColumnName("registration");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.IdPurchase);

                entity.Property(e => e.IdPurchase).HasColumnName("id_purchase");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.IdProductPurchases).HasColumnName("id_product_purchases");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.IdProductPurchasesNavigation)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.IdProductPurchases)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Purchases_Products");
            });

            modelBuilder.Entity<RelationPc>(entity =>
            {
                entity.HasKey(e => e.IdRelationPc)
                    .HasName("PK_Realtion_PC");

                entity.ToTable("Relation_PC");

                entity.Property(e => e.IdRelationPc).HasColumnName("id_relation_PC");

                entity.Property(e => e.IdCategoryPc).HasColumnName("id_category_PC");

                entity.Property(e => e.IdProductPc).HasColumnName("id_product_PC");

                entity.HasOne(d => d.IdCategoryPcNavigation)
                    .WithMany(p => p.RelationPcs)
                    .HasForeignKey(d => d.IdCategoryPc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Realtion_PC_Сategories");

                entity.HasOne(d => d.IdProductPcNavigation)
                    .WithMany(p => p.RelationPcs)
                    .HasForeignKey(d => d.IdProductPc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Realtion_PC_Products1");
            });

            modelBuilder.Entity<Сategory>(entity =>
            {
                entity.HasKey(e => e.IdCategory);

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.NameCategory)
                    .HasMaxLength(60)
                    .HasColumnName("name_category");
            });

            modelBuilder.Entity<Сategory>().HasData(new Сategory { IdCategory = 1, NameCategory = "Напитки"},
            new Сategory { IdCategory = 2, NameCategory = "Мясо" },
            new Сategory { IdCategory = 3, NameCategory = "Молочные продукты" },
            new Сategory { IdCategory = 4, NameCategory = "Морепродукты" },
            new Сategory { IdCategory = 5, NameCategory = "Полуфабрикат" },
            new Сategory { IdCategory = 6, NameCategory = "Готовый продукт" },
            new Сategory { IdCategory = 7, NameCategory = "Овощи" },
            new Сategory { IdCategory = 8, NameCategory = "Приправа" },
            new Сategory { IdCategory = 9, NameCategory = "Сладкое" },
            new Сategory { IdCategory = 10, NameCategory = "Острое" },
            new Сategory { IdCategory = 11, NameCategory = "Зерно-мучные товары" },
            new Сategory { IdCategory = 12, NameCategory = "Свежее" },
            new Сategory { IdCategory = 13, NameCategory = "Замороженное" }

            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
