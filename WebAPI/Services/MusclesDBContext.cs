using Microsoft.EntityFrameworkCore;
using Models;

namespace Services
{
    public class MusclesDBContext : DbContext
    {
        public MusclesDBContext(): base()
        {

        }
        public MusclesDBContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PTKBD3O\\SQLEXPRESS01;Database=MusclesDB;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseType>().Property(a => a.TargetedMuscle).HasConversion<string>();
            modelBuilder.Entity<ExerciseType>().Property(o => o.Equipment).HasConversion<string>();
            modelBuilder.Entity<Workout>().HasOne(e => e.Creator).WithMany(e => e.Workouts).HasForeignKey(c => c.CreatorId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutHistory> History { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseType> ExerciseTypes { get; set; }
        public DbSet<ExerciseTypeGroup> ExerciseTypeGroups { get; set; }


    }
}
