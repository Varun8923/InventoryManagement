using System;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Inventory.Core;

#nullable disable

namespace Inventory.Dto.Models
{
    public partial class InventoryManagementContext : DbContext
    {
        public InventoryManagementContext()
        {
        }

        public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options)
            : base(options)
        {
        }

        public void InsertUser(string Email, string Password, int Designation, string IP, string FirstName, string LastName, bool IsActive, DateTime CreatedOn )
        {
            // Call the stored procedure using FromSqlRaw or ExecuteSqlRawAsync
              Database.ExecuteSqlRaw("EXECUTE SaveUserData @Email, @Passwoed, @RoleId, @IP, @FirstName, @LastName, " +
                  "@IsActive, @CreatedOn",           
                new SqlParameter("@Email", Email),
            new SqlParameter("@Passwoed", Password),
            new SqlParameter("@RoleId", Designation),
            new SqlParameter("@IP", IP),
            new SqlParameter("@FirstName", FirstName),
            new SqlParameter("@LastName", LastName),
            new SqlParameter("@IsActive", IsActive),
            new SqlParameter("@CreatedOn", CreatedOn)

                );
        }
    

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Subcategory> Subcategories { get; set; }
        public virtual DbSet<TblDisignation> TblDisignations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER01;Database=InventoryManagement;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CategoryDecription)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).ValueGeneratedOnAdd();

                entity.Property(e => e.CategoryTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreadtedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Disctrict).HasMaxLength(200);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Person__User_Id__4AB81AF0");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.AddedOn).HasColumnType("datetime");

                entity.Property(e => e.RoleIsActive).HasColumnName("Role_IsActive");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreadetOn).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SubcategoryId).ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblDisignation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_Disignation");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateIpAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DisignationId).ValueGeneratedOnAdd();

                entity.Property(e => e.DisignationName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ip)
                    .HasMaxLength(200)
                    .HasColumnName("IP");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChange).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(200)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserRole__UserId__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
