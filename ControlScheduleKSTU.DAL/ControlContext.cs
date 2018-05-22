using System.Data.Entity;
using ControlScheduleKSTU.DomainCore.Models;
using DayOfWeek = ControlScheduleKSTU.DomainCore.Models.DayOfWeek;

namespace ControlScheduleKSTU.DAL
{
    public partial class ControlContext : DbContext
    {
        public ControlContext()
            : base("name=ControlContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Auditorium> Auditoriums { get; set; }
        public virtual DbSet<AuditoriumType> AuditoriumTypes { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseGroup> CourseGroups { get; set; }
        public virtual DbSet<Criterion> Criteria { get; set; }
        public virtual DbSet<DayOfWeek> DayOfWeeks { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Hour> Hours { get; set; }
        public virtual DbSet<Raschasovka> Raschasovkas { get; set; }
        public virtual DbSet<RaschasovkaWeek> RaschasovkaWeeks { get; set; }
        public virtual DbSet<RaschasovkaYear> RaschasovkaYears { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ScheduleRealization> ScheduleRealizations { get; set; }
        public virtual DbSet<ScheduleYear> ScheduleYears { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectDepartment> SubjectDepartments { get; set; }
        public virtual DbSet<SubjectType> SubjectTypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherDepartment> TeacherDepartments { get; set; }
        public virtual DbSet<TeacherPersonalTime> TeacherPersonalTimes { get; set; }
        public virtual DbSet<Week> Weeks { get; set; }
        public virtual DbSet<Year> Years { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Auditorium>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.Auditorium)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Auditorium>()
                .HasMany(e => e.ScheduleRealizations)
                .WithOptional(e => e.Auditorium)
                .HasForeignKey(e => e.ActualAuditoriumId);

            modelBuilder.Entity<Auditorium>()
                .HasMany(e => e.ScheduleYears)
                .WithRequired(e => e.Auditorium)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.CourseGroups)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Raschasovkas)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.RaschasovkaYears)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DayOfWeek>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.DayOfWeek)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DayOfWeek>()
                .HasMany(e => e.ScheduleYears)
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
                .HasMany(e => e.Raschasovkas)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.RaschasovkaYears)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.TeacherDepartments)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.CourseGroups)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Raschasovkas)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.RaschasovkaYears)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.ScheduleYears)
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
                .HasMany(e => e.ScheduleYears)
                .WithRequired(e => e.Hour)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hour>()
                .HasMany(e => e.TeacherPersonalTimes)
                .WithRequired(e => e.Hour)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Raschasovka>()
                .HasMany(e => e.RaschasovkaWeeks)
                .WithRequired(e => e.Raschasovka)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ScheduleRealization>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Semester>()
                .HasMany(e => e.Raschasovkas)
                .WithRequired(e => e.Semester)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Semester>()
                .HasMany(e => e.RaschasovkaYears)
                .WithRequired(e => e.Semester)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Semester>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.Semester)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Semester>()
                .HasMany(e => e.ScheduleYears)
                .WithRequired(e => e.Semester)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Raschasovkas)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.RaschasovkaYears)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.ScheduleYears)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.SubjectDepartments)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubjectType>()
                .Property(e => e.FullName)
                .IsFixedLength();

            modelBuilder.Entity<SubjectType>()
                .HasMany(e => e.Raschasovkas)
                .WithRequired(e => e.SubjectType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubjectType>()
                .HasMany(e => e.RaschasovkaYears)
                .WithRequired(e => e.SubjectType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubjectType>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.SubjectType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubjectType>()
                .HasMany(e => e.ScheduleYears)
                .WithRequired(e => e.SubjectType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Raschasovkas)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.RaschasovkaYears)
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
                .HasMany(e => e.ScheduleYears)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.TeacherDepartments)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.TeacherPersonalTimes)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Week>()
                .HasMany(e => e.RaschasovkaWeeks)
                .WithRequired(e => e.Week)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Week>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.Week)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Week>()
                .HasMany(e => e.ScheduleYears)
                .WithRequired(e => e.Week)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Year>()
                .HasMany(e => e.RaschasovkaYears)
                .WithRequired(e => e.Year)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Year>()
                .HasMany(e => e.ScheduleYears)
                .WithRequired(e => e.Year)
                .WillCascadeOnDelete(false);
        }

       
    }
}
