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
using ControlScheduleKSTU.DomainCore.Resourses;
using ControlScheduleKSTU.Service.Services;

namespace ControlScheduleKSTU.WebApp.Controllers
{
    [Authorize]
    public class ScheduleRealizationsController : Controller
    {
        private readonly ScheduleRealizationService _realizationService = new ScheduleRealizationService();

        // GET: ScheduleRealizations
        public async Task<ActionResult> Index()
        {
            ViewBag.Currentschedule = await _realizationService.GetCurrentScheduleByTime();
            if (ViewBag.Currentschedule == 0)
                ViewBag.Currentschedule = "--";
            ViewBag.title = Resources.MonitoringSchedule;
            return View( await _realizationService.GetScheduleRealizations());
        }

        // GET: ScheduleRealizations/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var scheduleRealization = await _realizationService.GetSeScheduleRealization(id);
            if (scheduleRealization == null)
            {
                return HttpNotFound();
            }
            return View(scheduleRealization);
        }

        // GET: ScheduleRealizations/Create
        //public ActionResult Create()
        //{
        //    ViewBag.ActualAuditoriumId = new SelectList(db.Auditoriums, "Id", "Name");
        //    ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "Id");
        //    ViewBag.ActualTeacherId = new SelectList(db.Teachers, "Id", "FirstName");
        //    return View();
        //}

        //// POST: ScheduleRealizations/Create
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,ActualDate,BeginTime,EndTime,ScheduleId,Description,ActualAuditoriumId,Location,ActualTeacherId")] ScheduleRealization scheduleRealization)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ScheduleRealizations.Add(scheduleRealization);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ActualAuditoriumId = new SelectList(db.Auditoriums, "Id", "Name", scheduleRealization.ActualAuditoriumId);
        //    ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "Id", scheduleRealization.ScheduleId);
        //    ViewBag.ActualTeacherId = new SelectList(db.Teachers, "Id", "FirstName", scheduleRealization.ActualTeacherId);
        //    return View(scheduleRealization);
        //}

        //// GET: ScheduleRealizations/Edit/5
        //public async Task<ActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ScheduleRealization scheduleRealization = await db.ScheduleRealizations.FindAsync(id);
        //    if (scheduleRealization == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ActualAuditoriumId = new SelectList(db.Auditoriums, "Id", "Name", scheduleRealization.ActualAuditoriumId);
        //    ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "Id", scheduleRealization.ScheduleId);
        //    ViewBag.ActualTeacherId = new SelectList(db.Teachers, "Id", "FirstName", scheduleRealization.ActualTeacherId);
        //    return View(scheduleRealization);
        //}

        //// POST: ScheduleRealizations/Edit/5
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,ActualDate,BeginTime,EndTime,ScheduleId,Description,ActualAuditoriumId,Location,ActualTeacherId")] ScheduleRealization scheduleRealization)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(scheduleRealization).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ActualAuditoriumId = new SelectList(db.Auditoriums, "Id", "Name", scheduleRealization.ActualAuditoriumId);
        //    ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "Id", scheduleRealization.ScheduleId);
        //    ViewBag.ActualTeacherId = new SelectList(db.Teachers, "Id", "FirstName", scheduleRealization.ActualTeacherId);
        //    return View(scheduleRealization);
        //}

        //// GET: ScheduleRealizations/Delete/5
        //public async Task<ActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ScheduleRealization scheduleRealization = await db.ScheduleRealizations.FindAsync(id);
        //    if (scheduleRealization == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(scheduleRealization);
        //}

        //// POST: ScheduleRealizations/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(string id)
        //{
        //    ScheduleRealization scheduleRealization = await db.ScheduleRealizations.FindAsync(id);
        //    db.ScheduleRealizations.Remove(scheduleRealization);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

    }
}
