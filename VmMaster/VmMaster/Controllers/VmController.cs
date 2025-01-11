using Microsoft.AspNetCore.Mvc;
using VmMaster.Dtos.Post;
using VmMaster.Models;

namespace VmMaster.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class VmController : Controller
    {
        [HttpGet("GetVmInfo")]
        public ActionResult<VmData> GetVmInfo(int vmId)
        {
            return Ok();
        }
        [HttpGet("ListVms")]
        public ActionResult<List<VmData>> ListVms()
        {
            return Ok();
        }
        [HttpPost("NewVm")]
        public ActionResult CreateVm([FromBody]CreateVmDto createVmDto)
        {
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
