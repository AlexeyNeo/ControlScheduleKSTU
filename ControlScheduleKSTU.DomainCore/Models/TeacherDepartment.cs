namespace ControlScheduleKSTU.DomainCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeacherDepartment")]
    public partial class TeacherDepartment
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }

        public short DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
