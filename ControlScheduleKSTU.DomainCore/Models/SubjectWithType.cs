namespace ControlScheduleKSTU.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubjectWithType")]
    public partial class SubjectWithType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubjectWithType()
        {
            Raschasovkas = new HashSet<Raschasovka>();
            Schedules = new HashSet<Schedule>();
        }

        public long Id { get; set; }

        public long SubjectId { get; set; }

        public byte SubjectTypeId { get; set; }

        public short? PreferAuditoriumId { get; set; }

        public virtual Auditorium Auditorium { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Raschasovka> Raschasovkas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedules { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual SubjectType SubjectType { get; set; }
    }
}
