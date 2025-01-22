namespace VmMaster.Models.DigitalOceanModels
{
    public class CreateDroplet
    {
        public string Name { get; set; } = "";
        public string Size { get; set; } = "";
        public string Image { get; set; } = "";
        public required List<string> SshKey { get; set; }
    }
}
