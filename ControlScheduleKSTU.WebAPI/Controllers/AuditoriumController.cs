using ControlScheduleKSTU.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ControlScheduleKSTU.DomainCore.Enums;
using ControlScheduleKSTU.DomainCore.ModelsView;
using ControlScheduleKSTU.WebAPI.Infrastructure;

namespace ControlScheduleKSTU.WebAPI.Controllers
{
    [MyAuthorize(RolesEnum = RolesEnum.Teacher)]
  
    public class AuditoriumController : ApiController
    {
        private readonly AuditoriumService _auditoriumService = new AuditoriumService();
        // GET api/<controller>
        [HttpGet]
        [Route("api/Auditorium/GetAuditoriumBuilding")]
        //[MyAuthorize(RolesEnum = RolesEnum.Teacher)]
        public async Task<List<AuditoriumViewModel>> GetAuditoriumBuilding(int buildingId)
        {
            var auditoriums = await _auditoriumService.GetAuditoriumInBuilding(buildingId);
            if(!auditoriums.Any())
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            return auditoriums;
        }
       // HttpResponseException(new HttpResponseMessage(HttpStatusCode.NoContent));
        // GET api/<controller>/5
        [HttpGet]
        [Route("api/Auditorium/Building/{id:int}/AuditoriumType")]
        
        public async Task<List<AuditoriumViewModel>> GetAuditoriumByAuditoriumType(int id, int auditoriumTypeId)
        {
            var auditoriums = await _auditoriumService.GetAuditoriumByAuditoriumType(id, auditoriumTypeId);
            if(!auditoriums.Any())
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            return auditoriums;
        }

        [HttpGet]
        [Route("api/Auditorium/Search")]
        public async Task<List<AuditoriumViewModel>> AuditoriumSearch(string name)
        {
            var auditory = await _auditoriumService.SearchByName(name);
            if(!auditory.Any())
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            return auditory;
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