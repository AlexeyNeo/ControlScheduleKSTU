namespace ControlScheduleKSTU.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Auditorium")]
    public partial class Auditorium
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Auditorium()
        {
            Raschasovkas = new HashSet<Raschasovka>();
            Schedules = new HashSet<Schedule>();
            ScheduleRealizations = new HashSet<ScheduleRealization>();
            SubjectWithTypes = new HashSet<SubjectWithType>();
        }

        public short Id { get; set; }

        public short? Number { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Аудитория")]
        public string Name { get; set; }

        public short? DepartmentId { get; set; }
        [Display(Name = "Вместительность")]
        public short SeatingCapacity { get; set; }

        public byte? AuditoriumTypeId { get; set; }

        public byte? BuildingId { get; set; }

        public DbGeography Location { get; set; }

        public virtual AuditoriumType AuditoriumType { get; set; }

        public virtual Building Building { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Raschasovka> Raschasovkas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScheduleRealization> ScheduleRealizations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubjectWithType> SubjectWithTypes { get; set; }
    }
}
