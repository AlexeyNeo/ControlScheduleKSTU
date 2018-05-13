using ControlScheduleKSTU.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ControlScheduleKSTU.DomainCore.ModelsView;

namespace ControlScheduleKSTU.WebAPI.Controllers
{
    public class AuditoriumController : ApiController
    {
        private readonly AuditoriumService _auditoriumService = new AuditoriumService();
        // GET api/<controller>
        [HttpGet]
        [Route("api/Auditorium/GetAuditoriumBuilding")]
        public async Task<List<AuditoriumViewModel>> GetAuditoriumBuilding(int buildingId)
        {
            return await _auditoriumService.GetAuditoriumInBuilding(buildingId);
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/Auditorium/Building/{id:int}/AuditoriumType")]
        public async Task<List<AuditoriumViewModel>> GetAuditoriumByAuditoriumType(int id, int auditoriumTypeId)
        {
            return await _auditoriumService.GetAuditoriumByAuditoriumType(id, auditoriumTypeId);
        }

        [HttpGet]
        [Route("api/Auditorium/Search")]
        public async Task<List<AuditoriumViewModel>> AuditoriumSearch(string name)
        {
            return await _auditoriumService.SearchByName(name);
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