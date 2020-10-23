using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookPatient.Models
{
    public partial class appointmentContext : DbContext
    {
        public appointmentContext()
        {
        }

        public appointmentContext(DbContextOptions<appointmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=deva;Database=appointment;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {     
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Admin__1788CC4C86F1202B");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {

                entity.ToTable("appointment");

                entity.Property(e => e.Confirmation)
                    .HasColumnName("confirmation")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorName)
                    .HasColumnName("doctor_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasColumnName("patient_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PatientNum).HasColumnName("patient_num");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("doctor");

                entity.Property(e => e.Available)
                    .HasColumnName("available")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Speciality)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PersonalId)
                    .HasName("PK__patient__C16BAC15A380159A");

                entity.ToTable("patient");

                entity.Property(e => e.PersonalId).HasColumnName("personal_id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.Property(e => e.Pname)
                    .HasColumnName("pname")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
