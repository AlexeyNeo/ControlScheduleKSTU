namespace ControlScheduleKSTU.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DayOfWeek")]
    public partial class DayOfWeek
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DayOfWeek()
        {
            Schedules = new HashSet<Schedule>();
            TeacherPersonalTimes = new HashSet<TeacherPersonalTime>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        public byte Number { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string FullName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeacherPersonalTime> TeacherPersonalTimes { get; set; }
    }
}
