namespace ControlScheduleKSTU.DomainCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RaschasovkaWeek
    {
        public long Id { get; set; }

        public int RaschasovkaId { get; set; }

        public byte WeekId { get; set; }

        public byte HoursForWeek { get; set; }

        public virtual Raschasovka Raschasovka { get; set; }

        public virtual Week Week { get; set; }
    }
}
