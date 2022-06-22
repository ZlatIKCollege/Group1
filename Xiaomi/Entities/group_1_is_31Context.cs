using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


#nullable disable

namespace Xiaomi
{
    public partial class group_1_is_31Context : DbContext
    {
        public group_1_is_31Context()
        {
        }

        public group_1_is_31Context(DbContextOptions<group_1_is_31Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=s.anosov.ru;port=7078;user=group_1_is_31;password=uxq8ly;database=group_1_is_31");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adress)
                    .HasMaxLength(50)
                    .HasColumnName("adress")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Contact)
                    .HasMaxLength(50)
                    .HasColumnName("contact")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.NameComp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name_comp")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.KolVo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("kol_vo")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Product1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("product")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Summa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("summa")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("surname")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NameRole).HasColumnName("name_role");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Client)
                    .HasMaxLength(50)
                    .HasColumnName("client");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.KolVo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("kol-vo")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Product)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("product")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Summa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("summa")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adress)
                    .HasMaxLength(50)
                    .HasColumnName("adress")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Contact)
                    .HasMaxLength(50)
                    .HasColumnName("contact")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Login, "login")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("Идентификатор");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address")
                    .HasComment("Адрес");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday")
                    .HasComment("Дата рождения");

                entity.Property(e => e.Contact)
                    .HasMaxLength(100)
                    .HasColumnName("contact")
                    .HasComment("Контактные данные");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("login")
                    .HasComment("Логин");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("name")
                    .HasComment("Имя");

                entity.Property(e => e.Passport)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("passport")
                    .HasComment("Паспортные данные");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password")
                    .HasComment("Пароль");

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("patronymic")
                    .HasComment("Отчество");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("surname")
                    .HasComment("Фамилия");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
