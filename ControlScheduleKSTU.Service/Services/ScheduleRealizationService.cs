using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ControlScheduleKSTU.DAL;
using ControlScheduleKSTU.DomainCore.Models;

namespace ControlScheduleKSTU.Service.Services
{
    public class ScheduleRealizationService : IDisposable
    {
        private readonly ControlContext _context = new ControlContext();
        public  async Task<List<ScheduleRealization>> GetScheduleRealizations()
        {
            return  await _context.ScheduleRealizations.Include(s => s.Auditorium).Include(s => s.Schedule).Include(s => s.Teacher).ToListAsync();
        }

        public async Task<ScheduleRealization> GetSeScheduleRealization(string id)
        {
            if (id == null)
                return null;

            var scheduleRealization =  await _context.ScheduleRealizations.FindAsync(id);

            if (scheduleRealization == null)
                return null;

            return scheduleRealization;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
