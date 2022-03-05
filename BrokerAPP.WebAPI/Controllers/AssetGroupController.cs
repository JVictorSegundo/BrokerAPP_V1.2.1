using BrokerAPP.Application.DTOs;
using BrokerAPP.Application.Repository.Interface;
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
    public class AssetGroupController : ControllerBase
    {
        private readonly IAssetGroupServiceDTO _repositoryDTO;
        public AssetGroupController (IAssetGroupServiceDTO repositoryDTO)
        {
            _repositoryDTO = repositoryDTO;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetGroupDTO>>> GetAll ()
        {
            var assetsGroupsList = await _repositoryDTO.GetAllAsync();
            if (assetsGroupsList == null)
                return NotFound("Error! AssetsGroups Not Found");
            return Ok(assetsGroupsList);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AssetGroupDTO>> GetById(int id)
        {
            var asset = await _repositoryDTO.GetByIdAsync(id);
            if (asset == null)
                return NotFound("ERROR! AssetGroup Not Found!");
            return Ok(asset);
        }

        [HttpGet("GetAssetByAssetGroupId/{assetGroupId}")]
        public async Task<ActionResult<IEnumerable<AssetDTO>>> GetAssetByAssetGroupId(int assetGroupId)
        {
            var assetList = await _repositoryDTO.GetAssetByAssetGroupId(assetGroupId);
            return Ok(assetList);
        }

        [HttpPost]
        public async Task<ActionResult<AssetGroupDTO>> Create(AssetGroupDTO assetGroup)
        {
            if (assetGroup == null)
                return BadRequest("Error! Body cannot be null");
            await _repositoryDTO.CreateAsync(assetGroup);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<AssetGroupDTO>> Delete(int id)
        {
            await _repositoryDTO.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<AssetGroupDTO>> Update(int id, [FromBody] AssetGroupDTO assetGroup)
        {
            if (assetGroup.Id != id)
                return BadRequest("ERROR! Ids must be equals");
            await _repositoryDTO.UpdateAsync(assetGroup);
            return Ok();
        }
    }
}
