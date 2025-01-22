using VmMaster.Dtos.Post;

namespace VmMaster.Interfaces
{
    public interface ICloudService
    {
        public Task CreateVM(CreateVmDto vmDto);
        public void DestroyVM();
        public void RenameVM(string name);
        public Task ListVM();
    }
}
