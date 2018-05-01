namespace ControlScheduleKSTU.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeacherPersonalTime")]
    public partial class TeacherPersonalTime
    {
        public long Id { get; set; }

        public int TeacherId { get; set; }

        public byte HourId { get; set; }

        public byte DayOfWeekId { get; set; }

        public virtual DayOfWeek DayOfWeek { get; set; }

        public virtual Hour Hour { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
