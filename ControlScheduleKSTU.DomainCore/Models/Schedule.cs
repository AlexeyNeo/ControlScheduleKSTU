namespace ControlScheduleKSTU.DomainCore.Models
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
            ScheduleWeeks = new HashSet<ScheduleWeek>();
        }

        public int Id { get; set; }

        public byte HourId { get; set; }

        public byte DayOfWeekId { get; set; }

        public long GroupId { get; set; }

        public int TeacherId { get; set; }

        public short AuditoriumId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastChange { get; set; }

        public bool? IsFinal { get; set; }

        public long SubjectId { get; set; }

        public byte SubjectTypeId { get; set; }

        public byte SemesterId { get; set; }

        public virtual Auditorium Auditorium { get; set; }

        public virtual DayOfWeek DayOfWeek { get; set; }

        public virtual Group Group { get; set; }

        public virtual Hour Hour { get; set; }

        public virtual Semester Semester { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual SubjectType SubjectType { get; set; }

        public virtual Teacher Teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScheduleRealization> ScheduleRealizations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScheduleWeek> ScheduleWeeks { get; set; }
    }
}
