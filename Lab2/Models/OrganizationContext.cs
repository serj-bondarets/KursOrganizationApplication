using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Lab2
{
    public partial class OrganizationContext : DbContext
    {
        public OrganizationContext()
        {
        }

        public OrganizationContext(DbContextOptions<OrganizationContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Departament> Departaments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeesDepartament> EmployeesDepartaments { get; set; }
        public virtual DbSet<EmployeesPerformingTask> EmployeesPerformingTasks { get; set; }
        public virtual DbSet<EmployeesProfession> EmployeesProfessions { get; set; }
        public virtual DbSet<Profession> Professions { get; set; }
        public virtual DbSet<ProfessionsDepartament> ProfessionsDepartaments { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Departament>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.FatherName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SupposedFinishCurrentTaskDate).HasColumnType("date");

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Profession)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ProfessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Professions1");
            });

            modelBuilder.Entity<EmployeesDepartament>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("EmployeesDepartaments");

                entity.Property(e => e.Departament)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProfessionName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<EmployeesPerformingTask>(entity =>
            {
                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeesPerformingTasks)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeesPerformingTasks_Employees");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.EmployeesPerformingTasks)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeesPerformingTasks_Tasks");
            });

            modelBuilder.Entity<EmployeesProfession>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("EmployeesProfessions");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ProfessionName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Profession>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Departament)
                    .WithMany(p => p.Professions)
                    .HasForeignKey(d => d.DepartamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Qualifications_Departaments");
            });

            modelBuilder.Entity<ProfessionsDepartament>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProfessionsDepartaments");

                entity.Property(e => e.Departament)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProfessionName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartProjectDate).HasColumnType("date");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.ControlDate).HasColumnType("date");

                entity.Property(e => e.Deadline).HasColumnType("date");

                entity.Property(e => e.FailureReason).HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tasks_Projects");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
