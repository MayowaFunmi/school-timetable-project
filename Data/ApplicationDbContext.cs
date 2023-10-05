using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolTimeTable.Models;

namespace SchoolTimeTable.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<ClassArm> ClassArms { get; set; }
        public DbSet<Period> Periods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.School)
                .WithOne(s => s.Admin)
                .HasForeignKey<School>(s => s.AdminId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
                
            modelBuilder.Entity<ClassArm>()
                .HasOne(c => c.School)
                .WithMany()
                .HasForeignKey(c => c.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClassArm>()
                .HasOne(c => c.StudentClass)
                .WithMany()
                .HasForeignKey(c => c.StudentClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClassArm>()
                .HasOne(c => c.Department)
                .WithMany()
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
