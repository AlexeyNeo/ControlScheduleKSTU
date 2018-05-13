using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ControlScheduleKSTU.DomainCore.ModelsView;
using ControlScheduleKSTU.Service.Services;
using Microsoft.Ajax.Utilities;

namespace ControlScheduleKSTU.WebAPI.Controllers
{
    public class TeacherController : ApiController
    {
        private readonly TeacherService _teacherService = new TeacherService();


        // GET api/<controller>
        [HttpGet]
        public async Task<List<TeacherViewModel>>Get()
        {
            var teachers = await _teacherService.GetTeachers();
            if(!teachers.Any())
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NoContent));
            return await _teacherService.GetTeachers();
        }

        // GET api/<controller>/5
        [HttpGet]
        public async Task<TeacherViewModel> Get(int id)
        {
            var teacher = await _teacherService.GetTeacher(id);
            if(teacher == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return teacher;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}