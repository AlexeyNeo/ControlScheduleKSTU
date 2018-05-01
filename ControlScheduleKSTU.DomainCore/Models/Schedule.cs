namespace ControlScheduleKSTU.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Schedule")]
    public partial class Schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Schedule()
        {
            ScheduleRealizations = new HashSet<ScheduleRealization>();
        }

        public int Id { get; set; }

        public byte HourId { get; set; }

        public byte DayOfWeekId { get; set; }

        public long GroupId { get; set; }

        public int TeacherId { get; set; }

        public long SubjectWithTypeId { get; set; }

        public short AuditoriumId { get; set; }

        public byte WeekId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastChange { get; set; }

        public bool? IsFinal { get; set; }

        public virtual Auditorium Auditorium { get; set; }

        public virtual DayOfWeek DayOfWeek { get; set; }

        public virtual Group Group { get; set; }

        public virtual Hour Hour { get; set; }

        public virtual SubjectWithType SubjectWithType { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Week Week { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScheduleRealization> ScheduleRealizations { get; set; }
    }
}
