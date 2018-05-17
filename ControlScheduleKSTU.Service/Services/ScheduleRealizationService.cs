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
        public  async Task<List<ScheduleRealization>> GetScheduleRealizations()
        {
            //var views = new List<ScheduleRealizationView>();
            var schedules = await _context.ScheduleRealizations.Include(s => s.Auditorium).Include(s => s.Schedule).Include(s => s.Teacher).ToListAsync();
            //foreach (var schedule in schedules)
            //{
            //    var view = new ScheduleRealizationView();

            //    var teacher = schedule.Schedule.Teacher;
            //    var auditorium = schedule.Schedule.Auditorium;
            //}
            return schedules;

        }

        public async Task<ScheduleRealization> GetSeScheduleRealization(string id)
        {
            var scheduleRealization =  await _context.ScheduleRealizations.FindAsync(id);

            return scheduleRealization;
        }

        public int GetCurrentScheduleByTime()
        {
            DateTime currentDate = DateTime.Now;
            var currentTime = TimeSpan.Parse(currentDate.ToString("HH:mm:ss"));
            var schedule = _context.Hours.FirstOrDefault(c => c.End >= currentTime && c.Begin<= currentTime);
            if (schedule == null) return 0;
            return schedule.Number;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
