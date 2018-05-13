using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ControlScheduleKSTU.DAL;
using ControlScheduleKSTU.DomainCore.ModelsView;

namespace ControlScheduleKSTU.Service.Services
{
    public class TeacherService: IDisposable
    {
        private readonly ControlContext _context = new ControlContext();

        public async Task<List<TeacherViewModel>> GetTeachers()
        {
            return await _context.Teachers.Select(c => new TeacherViewModel
            {
                Id = c.Id,
                LastName = c.LastName,
                FirstName = c.FirstName
            }).ToListAsync();
        }
        public async Task<TeacherViewModel> GetTeacher(int teacherId)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(c => c.Id == teacherId);
            if (teacher == null) return null;
            return new TeacherViewModel
            {
                Id = teacher.Id,
                LastName = teacher.LastName,
                FirstName = teacher.FirstName
            };
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
