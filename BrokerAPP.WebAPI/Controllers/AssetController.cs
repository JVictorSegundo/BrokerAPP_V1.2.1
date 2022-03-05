using BrokerAPP.Application.DTOs;
using BrokerAPP.Application.Repository.Interface;
using BrokerAPP.Domain;
using BrokerAPP.Infra.DBContext;
using BrokerAPP.Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrokerAPP.WebAPI.Controllers
{
    [Route("BrokerAPPWebAPI/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetServiceDTO _repositoryDTO;
        public AssetController (IAssetServiceDTO repositoryDTO)
        {
            _repositoryDTO = repositoryDTO;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetDTO>>> GetAll ()
        {
            var assetList = await _repositoryDTO.GetAllAsync();
            if (assetList == null)
                return NotFound("Error! Assets Not Found");
            return Ok(assetList);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AssetDTO>> GetById (int id)
        {
            var asset = await _repositoryDTO.GetByIdAsync(id);
            if (asset == null)
                return NotFound("ERROR! Asset Not Found!");
            return Ok(asset);
        }

        [HttpPost]
        public async Task<ActionResult<AssetDTO>> Create(AssetDTO asset)
        {
            if (asset == null)
                return BadRequest("Error! Body cannot be null");
            await _repositoryDTO.CreateAsync(asset);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<AssetDTO>> Delete (int id)
        {
            await _repositoryDTO.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<AssetDTO>> Update(int id, [FromBody] AssetDTO asset)
        {
            if (asset.Id != id)
                return BadRequest("ERROR! Ids must be equals");
            await _repositoryDTO.UpdateAsync(asset);
            return Ok();
        }
    }
}
