using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ControlScheduleKSTU.DAL;
using ControlScheduleKSTU.DomainCore.Models;
using ControlScheduleKSTU.DomainCore.ModelsView;
using ControlScheduleKSTU.Service.Services;

namespace ControlScheduleKSTU.WebAPI.Controllers
{
    
    public class ScheduleRealizationsController : ApiController
    {
        private readonly ScheduleRealizationService _scheduleRealization = new ScheduleRealizationService();

        // GET: api/ScheduleRealizations
        //[HttpGet]
        //[Route("api/Teacher/GetScheduleRealizations")]
        //public IQueryable<ScheduleRealization> GetScheduleRealizations()
        //{
        //    return _scheduleRealization.
        //}
        [HttpGet]
        [Route("api/Teacher/StartSchedule")]
        public  void StartSchedule(string id)
        {
             _scheduleRealization.BeginSchedule(id);
        }
        [HttpGet]
        [Route("api/Teacher/EndSchedule")]
        public  void EndSchedule(string id)
        {
            _scheduleRealization.EndSchedule(id);
        }
    }
}


//        // GET: api/ScheduleRealizations/5
//        [ResponseType(typeof(ScheduleRealization))]
////        public async Task<IHttpActionResult> GetScheduleRealization(string id)
//        {
//            ScheduleRealization scheduleRealization = await db.ScheduleRealizations.FindAsync(id);
//            if (scheduleRealization == null)
//            {
//                return NotFound();
//            }

//            return Ok(scheduleRealization);
//        }

//        // PUT: api/ScheduleRealizations/5
//        [ResponseType(typeof(void))]
//        public async Task<IHttpActionResult> PutScheduleRealization(string id, ScheduleRealization scheduleRealization)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != scheduleRealization.Id)
//            {
//                return BadRequest();
//            }

//            db.Entry(scheduleRealization).State = EntityState.Modified;

//            try
//            {
//                await db.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ScheduleRealizationExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/ScheduleRealizations
//        [ResponseType(typeof(ScheduleRealization))]
//        public async Task<IHttpActionResult> PostScheduleRealization(ScheduleRealization scheduleRealization)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.ScheduleRealizations.Add(scheduleRealization);

//            try
//            {
//                await db.SaveChangesAsync();
//            }
//            catch (DbUpdateException)
//            {
//                if (ScheduleRealizationExists(scheduleRealization.Id))
//                {
//                    return Conflict();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return CreatedAtRoute("DefaultApi", new { id = scheduleRealization.Id }, scheduleRealization);
//        }

//        // DELETE: api/ScheduleRealizations/5
//        [ResponseType(typeof(ScheduleRealization))]
//        public async Task<IHttpActionResult> DeleteScheduleRealization(string id)
//        {
//            ScheduleRealization scheduleRealization = await db.ScheduleRealizations.FindAsync(id);
//            if (scheduleRealization == null)
//            {
//                return NotFound();
//            }

//            db.ScheduleRealizations.Remove(scheduleRealization);
//            await db.SaveChangesAsync();

//            return Ok(scheduleRealization);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool ScheduleRealizationExists(string id)
//        {
//            return db.ScheduleRealizations.Count(e => e.Id == id) > 0;
//        }
//    }
//}