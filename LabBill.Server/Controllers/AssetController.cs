using LabBill.Server.Service.AssetService;
using LabBill.Shared;
using LabBill.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace LabBill.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase {
        private readonly IAssetService _assetService;
        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet("{assetId}")]
        public async Task<ActionResult<ServiceResponse<Asset>>> GetPersonById(int assetId)
        {
            var result = await _assetService.GetAssetById(assetId);
            return Ok(result);
        }
    }
}