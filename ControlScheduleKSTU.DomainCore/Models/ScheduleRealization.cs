namespace ControlScheduleKSTU.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ScheduleRealization")]
    public partial class ScheduleRealization
    {
        public string Id { get; set; }
        [Display(Name = "Назначенная дата")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yy}")]
        public DateTime? ActualDate { get; set; }
        [Display(Name = "Время начала")]
        
        public TimeSpan? BeginTime { get; set; }
        [Display(Name = "Время завершения")]
        public TimeSpan? EndTime { get; set; }

        public int? ScheduleId { get; set; }
        [Display(Name = "Комментарий преподавателя")]
        public string Description { get; set; }

        public short? ActualAuditoriumId { get; set; }

        public DbGeography Location { get; set; }

        public int? ActualTeacherId { get; set; }

        public virtual Auditorium Auditorium { get; set; }

        public virtual Schedule Schedule { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
