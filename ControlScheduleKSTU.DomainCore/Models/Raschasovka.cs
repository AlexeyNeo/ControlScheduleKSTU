namespace ControlScheduleKSTU.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Raschasovka")]
    public partial class Raschasovka
    {
        public int Id { get; set; }

        public int Potok { get; set; }

        public byte CourseId { get; set; }

        public int TeacherId { get; set; }

        public long SubjectWithTypeId { get; set; }

        public short TotalHoursForSemestr { get; set; }

        public byte TotalHoursForWeek { get; set; }

        public byte WeekId { get; set; }

        public short? AuditoriumId { get; set; }

        public virtual Auditorium Auditorium { get; set; }

        public virtual Course Course { get; set; }

        public virtual SubjectWithType SubjectWithType { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Week Week { get; set; }
    }
}
