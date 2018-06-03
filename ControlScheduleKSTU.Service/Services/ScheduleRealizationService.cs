using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ControlScheduleKSTU.DAL;
using ControlScheduleKSTU.DomainCore.Models;
using ControlScheduleKSTU.DomainCore.ModelsView;

namespace ControlScheduleKSTU.Service.Services
{
    public class ScheduleRealizationService : IDisposable
    {
        private readonly ControlContext _context = new ControlContext();
        public  async Task<List<ScheduleRealizationView>> GetScheduleRealizations()
        {
            var views = new List<ScheduleRealizationView>();
            var schedules = await _context.ScheduleRealizations.ToListAsync();
            foreach (var schedule in schedules)
            {
                string timeBegin = "--";
                string temeEnd = "--";
                if (schedule.BeginTime != null)
                     timeBegin = String.Format("{0:HH:mm:ss}", new DateTime(schedule.BeginTime.Value.Ticks));
                if(schedule.EndTime != null)
                    temeEnd = String.Format("{0:HH:mm:ss}", new DateTime(schedule.BeginTime.Value.Ticks));
                var view = new ScheduleRealizationView
                {
                    //ActualAuditorium = schedule.Schedule.Auditorium.Name,
                    Auditorium = schedule.Schedule.Auditorium.Name,
                    ActualDate = schedule.ActualDate.Value,
                  //  ActualTeacher = schedule.Teacher.FirstName + schedule.Teacher.LastName ??"",
                    Teacher = (schedule.Schedule.Teacher.LastName + " " +schedule.Schedule.Teacher.FirstName) ??
                    schedule.Teacher.LastName + " "+schedule.Teacher.FirstName ,
                    BeginTime = timeBegin,
                    ScheduleName = schedule.Schedule.Subject.FullName,
                    Description = schedule.Description,
                    EndTime = temeEnd,
                  //  Id = schedule.ScheduleId.Value
                };
                views.Add(view);
            }
            return views;

        }

        public async Task<ScheduleRealization> GetSeScheduleRealization(string id)
        {
            var scheduleRealization =  await _context.ScheduleRealizations.FindAsync(id);

            return scheduleRealization;
        }

        public async Task<int> GetCurrentScheduleByTime()
        {
            DateTime currentDate = DateTime.Now.ToUniversalTime().AddHours(6);
            var currentTime = TimeSpan.Parse(currentDate.ToString("HH:mm:ss"));
            var schedule = await _context.Hours.FirstOrDefaultAsync(c => c.End >= currentTime && c.Begin<= currentTime);
            if (schedule == null) return 0;
            return schedule.Number;
        }

        public  void  BeginSchedule(string scheduleId)
        {
            var schedule = _context.ScheduleRealizations.FirstOrDefault(c => c.Id == scheduleId);
            if (schedule == null) throw new Exception("Не найдено");
            schedule.BeginTime = DateTime.Now.TimeOfDay;
            _context.SaveChanges();
        }
        public void EndSchedule(string scheduleId)
        {
            var schedule =  _context.ScheduleRealizations.FirstOrDefault(c => c.Id == scheduleId);
            if (schedule == null) throw new Exception("Не найдено");
            schedule.EndTime = DateTime.Now.TimeOfDay;
            _context.SaveChanges();
        }


        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
