using System;
using CheckingEmployees.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CheckingEmployees
{
    public partial class CheckEmployeesContext : DbContext
    {
        public CheckEmployeesContext()
        {
        }

        public CheckEmployeesContext(DbContextOptions<CheckEmployeesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FormAbsence> FormAbsences { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-TKKKLMA;Database=CheckEmployees;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<FormAbsence>(entity =>
            {
                entity.ToTable("FormAbsence");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("description");

                entity.Property(e => e.Discounted).HasColumnName("discounted");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Reason).HasColumnName("reason");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
