namespace ControlScheduleKSTU.DomainCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ScheduleWeek
    {
        public long Id { get; set; }

        public int ScheduleId { get; set; }

        public byte WeekId { get; set; }

        public virtual Schedule Schedule { get; set; }

        public virtual Week Week { get; set; }
    }
}
