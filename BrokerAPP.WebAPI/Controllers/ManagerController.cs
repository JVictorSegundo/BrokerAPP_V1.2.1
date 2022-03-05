using BrokerAPP.Domain;
using BrokerAPP.Infra.DBContext;
using BrokerAPP.Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrokerAPP.WebAPI.Controllers
{
    [Route("BrokerAPPWebAPI/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerRepository _repository;
        public ManagerController (IManagerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> GetAll ()
        {
            var managerList = await _repository.GetAllAsync();
            if (managerList == null)
                return NotFound("Error! Managers Not Found");
            return Ok(managerList);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Manager>> GetById (int id)
        {
            var manager = await _repository.GetByIdAsync(id);
            if (manager == null)
                return NotFound("ERROR! Manager Not Found!");
            return Ok(manager);
        }

        [HttpGet("GetClientsByManagerId/{managerId}")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClientsByManagerId (int managerId)
        {
            var clientList = await _repository.GetClientsByManagerId(managerId);
            return Ok(clientList);
        }

        [HttpPost]
        public async Task<ActionResult<Manager>> Create(Manager manager)
        {
            if (manager == null)
                return BadRequest("Error! Body cannot be null");
            await _repository.CreateAsync(manager);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<Manager>> Delete (int id)
        {
            var managerById = await _repository.GetByIdAsync(id);
            if (managerById == null)
                return NotFound("ERROR! Manager Not Found!");
            await _repository.DeleteAsync(managerById);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Manager>> Update (int id, [FromBody] Manager manager)
        {
            if (manager.Id != id)
                return BadRequest("ERROR! Ids must be equals");
            await _repository.UpdateAsync(manager);
            return Ok();
        }
    }
}
