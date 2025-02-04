using VmMaster.Classes;
using VmMaster.Dtos.Post;
using VmMaster.Models;

namespace VmMaster.Interfaces
{
    public interface ICloudService
    {
        public Task CreateVM(CreateVmDto vmDto);
        public Task DestroyVM(int vmId);
        public Task RenameVM(string name, int vmId);
        public Task<List<VmData>> ListVM();
        public Task<DropletSizesResponse> GetSizes();
    }
}
