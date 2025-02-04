using Microsoft.AspNetCore.Mvc;
using VmMaster.Classes;
using VmMaster.Dtos.Post;
using VmMaster.Interfaces;
using VmMaster.Models;
using VmMaster.Services;
using VmMaster.Utils;

namespace VmMaster.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class VmController : Controller
    {
        private readonly ServiceFactory<ICloudService> _cloudServiceFactory;
        public VmController(ServiceFactory<ICloudService> cloudServiceFactory)
        {
            _cloudServiceFactory = cloudServiceFactory;
        }
        
        [HttpGet("GetSizesInfo")]
        public async Task<ActionResult<DropletSizesResponse>> GetSizes()
        {
            ICloudService? digitalOceanService = _cloudServiceFactory.GetService(typeof(DigitalOceanService));
            if (digitalOceanService is null)
            {
                throw new Exception("Cloud service does not exist");
            }
            DropletSizesResponse dropletSizesResponse = await digitalOceanService.GetSizes();

            return Ok(dropletSizesResponse);
        }
        [HttpGet("ListVms")]
        public async Task<ActionResult<List<VmData>>> ListVms()
        {
            ICloudService? digitalOceanService = _cloudServiceFactory.GetService(typeof(DigitalOceanService));
            if (digitalOceanService is null)
            {
                throw new Exception("Cloud service does not exist");
            }
            List<VmData> vmData = await digitalOceanService.ListVM();

            return Ok(vmData);
        }
        [HttpPost("NewVm")]
        public async Task<ActionResult> CreateVm([FromBody]CreateVmDto createVmDto)
        {
            ICloudService? digitalOceanService = _cloudServiceFactory.GetService(typeof(DigitalOceanService));
            if (digitalOceanService is null)
            {
                throw new Exception("Cloud service does not exist");
            }
            await digitalOceanService.CreateVM(createVmDto);
            return Ok();
        }
        [HttpPost("RenameVm")]
        public async Task<ActionResult> RenameVm(string name, int vmId)
        {
            ICloudService? digitalOceanService = _cloudServiceFactory.GetService(typeof(DigitalOceanService));
            if (digitalOceanService is null)
            {
                throw new Exception("Cloud service does not exist");
            }
            await digitalOceanService.RenameVM(name, vmId);
            return Ok();
        }


        [HttpDelete("DeleteVm")]
        public async Task<ActionResult> DeleteVm(int vmId)
        {
            ICloudService? digitalOceanService = _cloudServiceFactory.GetService(typeof(DigitalOceanService));
            if (digitalOceanService is null)
            {
                throw new Exception("Cloud service does not exist");
            }
            await digitalOceanService.DestroyVM(vmId);
            return Ok();
        }
    }
}
