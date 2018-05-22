using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlScheduleKSTU.DomainCore.Models;

namespace ControlScheduleKSTU.DomainCore.ModelsView
{
    public class ScheduleRealizationView
    {
        public int Id { get; set; }
        [Display(Name = "Дата проведения")]
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-mm-yyyy}")]
        public DateTime ActualDate { get; set; }
        [Display(Name = "Время начала")]
        public TimeSpan? BeginTime { get; set; }

        [Display(Name = "Время окончания")]
        public TimeSpan? EndTime { get; set; }

        public string ScheduleId { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }

        public string ActualAuditorium { get; set; }

        public DbGeography Location { get; set; }

        public string ActualTeacher { get; set; }
        [Display(Name = "Аудитория")]
        public string Auditorium { get; set; }
        [Display(Name = "Предмет")]
        public string ScheduleName { get; set; }
        [Display(Name = "Преподаватель")]
        public string Teacher { get; set; }
    }
}
