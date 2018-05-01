namespace ControlScheduleKSTU.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseGroup")]
    public partial class CourseGroup
    {
        public long Id { get; set; }

        public byte CourseId { get; set; }

        public long GroupId { get; set; }

        public virtual Course Course { get; set; }

        public virtual Group Group { get; set; }
    }
}
