namespace ControlScheduleKSTU.DomainCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ScheduleYear
    {
        public int Id { get; set; }

        public byte HourId { get; set; }

        public byte DayOfWeekId { get; set; }

        public long GroupId { get; set; }

        public int TeacherId { get; set; }

        public short AuditoriumId { get; set; }

        public byte WeekId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastChange { get; set; }

        public bool? IsFinal { get; set; }

        public long SubjectId { get; set; }

        public byte SubjectTypeId { get; set; }

        public byte SemesterId { get; set; }

        public byte YearId { get; set; }

        public virtual Auditorium Auditorium { get; set; }

        public virtual DayOfWeek DayOfWeek { get; set; }

        public virtual Group Group { get; set; }

        public virtual Hour Hour { get; set; }

        public virtual Semester Semester { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual SubjectType SubjectType { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Week Week { get; set; }

        public virtual Year Year { get; set; }
    }
}
