using Microsoft.AspNetCore.Mvc;
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
        
        [HttpGet("GetVmInfo")]
        public ActionResult<VmData> GetVmInfo(int vmId)
        {
            return Ok();
        }
        [HttpGet("ListVms")]
        public ActionResult<List<VmData>> ListVms()
        {
            //current work

            return Ok();
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
        [HttpPut("RenameVm")]
        public ActionResult RenameVm(int vmId, string name)
        {
            return Ok();
        }


        [HttpDelete("DeleteVm")]
        public ActionResult DeleteVm(int vmId)
        {
            return Ok();
        }
    }
}
