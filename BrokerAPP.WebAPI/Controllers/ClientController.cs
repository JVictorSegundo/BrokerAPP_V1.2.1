using BrokerAPP.Domain;
using BrokerAPP.Domain.EntitiesRelationship;
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
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repository;
        public ClientController (IClientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetAll ()
        {
            var clientList = await _repository.GetAllAsync();
            if (clientList == null)
                return NotFound("Error! Clients Not Found");
            return Ok(clientList);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Client>> GetById (int id)
        {
            var client = await _repository.GetByIdAsync(id);
            if (client == null)
                return NotFound("ERROR! Asset Not Found!");
            return Ok(client);
        }

        [HttpGet("GetAssetsByClientId/{clientId}")]
        public async Task<ActionResult<IEnumerable<ClientAsset>>> GetAssetsByClientId(int clientId)
        {
            var assetList = await _repository.GetAssetsByClientId(clientId);
            return Ok(assetList);
        }

        [HttpPost]
        public async Task<ActionResult<Client>> Create (Client client)
        {
            if (client == null)
                return BadRequest("Error! Body cannot be null");
            await _repository.CreateAsync(client);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<Client>> Delete (int id)
        {
            var clientById = await _repository.GetByIdAsync(id);
            if (clientById == null)
                return NotFound("ERROR! Asset Not Found!");
            await _repository.DeleteAsync(clientById);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Client>> Update(int id, [FromBody] Client client)
        {
            if (client.Id != id)
                return BadRequest("ERROR! Ids must be equals");
            await _repository.UpdateAsync(client);
            return Ok();
        }
    }
}
