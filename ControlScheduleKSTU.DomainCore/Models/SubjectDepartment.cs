namespace ControlScheduleKSTU.DomainCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubjectDepartment")]
    public partial class SubjectDepartment
    {
        public long Id { get; set; }

        public long SubjectId { get; set; }

        public short? DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
