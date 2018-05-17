using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControlScheduleKSTU.DAL;
using ControlScheduleKSTU.DomainCore.Models;

namespace ControlScheduleKSTU.WebApp.Controllers
{
    public class SchedulesController : Controller
    {
        private ControlContext db = new ControlContext();

        // GET: Schedules
        public async Task<ActionResult> Index()
        {
            var schedules = db.Schedules.Include(s => s.Auditorium).Include(s => s.DayOfWeek).Include(s => s.Group).Include(s => s.Hour).Include(s => s.Semester).Include(s => s.Subject).Include(s => s.SubjectType).Include(s => s.Teacher).Include(s => s.Week);
            return View(await schedules.ToListAsync());
        }

        // GET: Schedules/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = await db.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // GET: Schedules/Create
        public ActionResult Create()
        {
            ViewBag.AuditoriumId = new SelectList(db.Auditoriums, "Id", "Name");
            ViewBag.DayOfWeekId = new SelectList(db.DayOfWeeks, "Id", "Name");
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name");
            ViewBag.HourId = new SelectList(db.Hours, "Id", "Id");
            ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "Name");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            ViewBag.SubjectTypeId = new SelectList(db.SubjectTypes, "Id", "Name");
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "FirstName");
            ViewBag.WeekId = new SelectList(db.Weeks, "Id", "Id");
            return View();
        }

        // POST: Schedules/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,HourId,DayOfWeekId,GroupId,TeacherId,AuditoriumId,WeekId,LastChange,IsFinal,SubjectId,SubjectTypeId,SemesterId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Schedules.Add(schedule);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AuditoriumId = new SelectList(db.Auditoriums, "Id", "Name", schedule.AuditoriumId);
            ViewBag.DayOfWeekId = new SelectList(db.DayOfWeeks, "Id", "Name", schedule.DayOfWeekId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", schedule.GroupId);
            ViewBag.HourId = new SelectList(db.Hours, "Id", "Id", schedule.HourId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "Name", schedule.SemesterId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", schedule.SubjectId);
            ViewBag.SubjectTypeId = new SelectList(db.SubjectTypes, "Id", "Name", schedule.SubjectTypeId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "FirstName", schedule.TeacherId);
            ViewBag.WeekId = new SelectList(db.Weeks, "Id", "Id", schedule.WeekId);
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = await db.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuditoriumId = new SelectList(db.Auditoriums, "Id", "Name", schedule.AuditoriumId);
            ViewBag.DayOfWeekId = new SelectList(db.DayOfWeeks, "Id", "Name", schedule.DayOfWeekId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", schedule.GroupId);
            ViewBag.HourId = new SelectList(db.Hours, "Id", "Id", schedule.HourId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "Name", schedule.SemesterId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", schedule.SubjectId);
            ViewBag.SubjectTypeId = new SelectList(db.SubjectTypes, "Id", "Name", schedule.SubjectTypeId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "FirstName", schedule.TeacherId);
            ViewBag.WeekId = new SelectList(db.Weeks, "Id", "Id", schedule.WeekId);
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,HourId,DayOfWeekId,GroupId,TeacherId,AuditoriumId,WeekId,LastChange,IsFinal,SubjectId,SubjectTypeId,SemesterId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AuditoriumId = new SelectList(db.Auditoriums, "Id", "Name", schedule.AuditoriumId);
            ViewBag.DayOfWeekId = new SelectList(db.DayOfWeeks, "Id", "Name", schedule.DayOfWeekId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", schedule.GroupId);
            ViewBag.HourId = new SelectList(db.Hours, "Id", "Id", schedule.HourId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "Name", schedule.SemesterId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", schedule.SubjectId);
            ViewBag.SubjectTypeId = new SelectList(db.SubjectTypes, "Id", "Name", schedule.SubjectTypeId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "FirstName", schedule.TeacherId);
            ViewBag.WeekId = new SelectList(db.Weeks, "Id", "Id", schedule.WeekId);
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = await db.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Schedule schedule = await db.Schedules.FindAsync(id);
            db.Schedules.Remove(schedule);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
