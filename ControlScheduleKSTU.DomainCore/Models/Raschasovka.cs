namespace ControlScheduleKSTU.DomainCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Raschasovka")]
    public partial class Raschasovka
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Raschasovka()
        {
            RaschasovkaWeeks = new HashSet<RaschasovkaWeek>();
        }

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

        public byte NumberOfStudents { get; set; }

        public virtual Auditorium Auditorium { get; set; }

        public virtual Course Course { get; set; }

        public virtual Department Department { get; set; }

        public virtual Group Group { get; set; }

        public virtual Semester Semester { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual SubjectType SubjectType { get; set; }

        public virtual Teacher Teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaschasovkaWeek> RaschasovkaWeeks { get; set; }
    }
}
