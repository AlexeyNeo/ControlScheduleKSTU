using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlScheduleKSTU.DAL;
using ControlScheduleKSTU.DomainCore.Enums;
using ControlScheduleKSTU.DomainCore.Models;
using ControlScheduleKSTU.DomainCore.ModelsView;

namespace ControlScheduleKSTU.Service.Services
{
    public class AuditoriumService : IDisposable
    {
        private readonly ControlContext _context = new ControlContext();
        /// <summary>
        /// Учебные аудитории
        /// </summary>
        /// <param name="buildingId">ID корпуса</param>
        /// <returns></returns>
        public async Task<List<AuditoriumViewModel>> GetAuditoriumInBuilding(int buildingId)
        {

            var building = await _context.Buildings.FirstOrDefaultAsync(c => c.Id == buildingId);
            if (building == null) throw new Exception("buildingId не найден");
            var auditorium = await _context.Auditoriums.Where(m => m.BuildingId == buildingId)
                .Where(c => c.AuditoriumTypeId == (byte)AuditoriumTypeEnum.Laboratory ||
                            c.AuditoriumTypeId == (byte)AuditoriumTypeEnum.Lecture || 
                            c.AuditoriumTypeId == (byte)AuditoriumTypeEnum.Practical ||
                            c.AuditoriumTypeId == (byte)AuditoriumTypeEnum.Computer)

                .Select(m => new AuditoriumViewModel
            {
                Id = m.Id,
                Name = m.Name,
                AuditoriumType = m.AuditoriumType.FullName,
                Building = m.Building.FullName,
                Department = m.Department.FullName,
                SeatingCapacity = m.SeatingCapacity

            }).ToListAsync();
            return auditorium;
        }

        public async Task<List<AuditoriumViewModel>> GetAuditoriumByAuditoriumType(int buildingId, int auditoriumTypeId)
        {
            IQueryable<Auditorium> query = _context.Auditoriums;
            if (buildingId != 0)
                query = query.Where(c => c.BuildingId == buildingId);
            if (auditoriumTypeId != 0)
                query = query.Where(c => c.AuditoriumTypeId == auditoriumTypeId);

            return await query.Select(m => new AuditoriumViewModel
            {
                Id = m.Id,
                Name = m.Name,
                AuditoriumType = m.AuditoriumType.FullName,
                Building = m.Building.FullName,
                Department = m.Department.FullName,
                SeatingCapacity = m.SeatingCapacity
            }).ToListAsync();
        }

        public async Task<List<AuditoriumViewModel>> SearchByName(string name)
        {
            var auditorium = await _context.Auditoriums.Where(m => m.Name.Contains(name))
                .Where(c => c.AuditoriumTypeId == (byte)AuditoriumTypeEnum.Laboratory ||
                            c.AuditoriumTypeId == (byte)AuditoriumTypeEnum.Lecture ||
                            c.AuditoriumTypeId == (byte)AuditoriumTypeEnum.Practical ||
                            c.AuditoriumTypeId == (byte)AuditoriumTypeEnum.Computer
                            )
                .Select(m => new AuditoriumViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    AuditoriumType = m.AuditoriumType.FullName,
                    Building = m.Building.FullName,
                    Department = m.Department.FullName,
                    SeatingCapacity = m.SeatingCapacity

                }).ToListAsync();
            return auditorium;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
