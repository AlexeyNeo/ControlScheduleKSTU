namespace ControlScheduleKSTU.DAL
{
    using System.Data.Entity;

    public partial class DbContextKSTU : DbContext
    {
        public DbContextKSTU()
            : base("name=DbContext")
        {
        }

        public virtual DbSet<Auditorium> Auditoriums { get; set; }
        public virtual DbSet<AuditoriumType> AuditoriumTypes { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseGroup> CourseGroups { get; set; }
        public virtual DbSet<DayOfWeek> DayOfWeeks { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Hour> Hours { get; set; }
        public virtual DbSet<Raschasovka> Raschasovkas { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ScheduleRealization> ScheduleRealizations { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectType> SubjectTypes { get; set; }
        public virtual DbSet<SubjectWithType> SubjectWithTypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherPersonalTime> TeacherPersonalTimes { get; set; }
        public virtual DbSet<Week> Weeks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auditorium>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.Auditorium)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Auditorium>()
                .HasMany(e => e.ScheduleRealizations)
                .WithOptional(e => e.Auditorium)
                .HasForeignKey(e => e.ActualAuditoriumId);

            modelBuilder.Entity<Auditorium>()
                .HasMany(e => e.SubjectWithTypes)
                .WithOptional(e => e.Auditorium)
                .HasForeignKey(e => e.PreferAuditoriumId);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.CourseGroups)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Raschasovkas)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DayOfWeek>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.DayOfWeek)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DayOfWeek>()
                .HasMany(e => e.TeacherPersonalTimes)
                .WithRequired(e => e.DayOfWeek)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Subjects)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Teachers)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.CourseGroups)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hour>()
                .Property(e => e.Begin)
                .HasPrecision(0);

            modelBuilder.Entity<Hour>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.Hour)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hour>()
                .HasMany(e => e.TeacherPersonalTimes)
                .WithRequired(e => e.Hour)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ScheduleRealization>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.SubjectWithTypes)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubjectType>()
                .HasMany(e => e.SubjectWithTypes)
                .WithRequired(e => e.SubjectType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubjectWithType>()
                .HasMany(e => e.Raschasovkas)
                .WithRequired(e => e.SubjectWithType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubjectWithType>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.SubjectWithType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Raschasovkas)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.ScheduleRealizations)
                .WithOptional(e => e.Teacher)
                .HasForeignKey(e => e.ActualTeacherId);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.TeacherPersonalTimes)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Week>()
                .HasMany(e => e.Raschasovkas)
                .WithRequired(e => e.Week)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Week>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.Week)
                .WillCascadeOnDelete(false);
        }
        public virtual void Commit()
        {
            base.SaveChangesAsync().Wait();
        }
    }
}
