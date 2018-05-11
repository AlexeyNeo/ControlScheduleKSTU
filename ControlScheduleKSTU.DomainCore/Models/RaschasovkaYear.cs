namespace ControlScheduleKSTU.DomainCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RaschasovkaYear
    {
        public int Id { get; set; }

        public int Potok { get; set; }

        public byte CourseId { get; set; }

        public int TeacherId { get; set; }

        public short TotalHoursForSemestr { get; set; }

        public short? AuditoriumId { get; set; }

        public long GroupId { get; set; }

        public short DepartmentId { get; set; }

        public byte SemesterId { get; set; }

        public long SubjectId { get; set; }

        public byte SubjectTypeId { get; set; }

        public byte YearId { get; set; }

        public virtual Auditorium Auditorium { get; set; }

        public virtual Course Course { get; set; }

        public virtual Department Department { get; set; }

        public virtual Group Group { get; set; }

        public virtual Semester Semester { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual SubjectType SubjectType { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Year Year { get; set; }
    }
}
