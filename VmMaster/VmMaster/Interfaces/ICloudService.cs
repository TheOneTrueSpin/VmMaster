namespace VmMaster.Interfaces
{
    public interface ICloudService
    {
        public void CreateVM();
        public void DestroyVM();
        public void RenameVM(string name);
    }
}
