namespace VmMaster.Models
{
    public class VmData
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Region { get; set; } = "";
        public string Size { get; set; } = "";
        public string Image { get; set; } = "";
        public required List<string> SshKey { get; set; }
        
    }
}
