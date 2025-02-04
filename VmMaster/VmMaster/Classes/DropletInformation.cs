using System.Numerics;
using VmMaster.Models;

namespace VmMaster.Classes
{
    public class DropletInformation
    {
        public required int id { get; set; }
        public required string name { get; set; }
        public required int memory { get; set; }
        public required int disk { get; set; }
        public required string status { get; set; }
        public required string created_at { get; set; }
        public required string size_slug { get; set; }
        public static explicit operator VmData(DropletInformation dropletInformation)
        {
            VmData vmData = new VmData()
            {
                Id = dropletInformation.id,
                Name = dropletInformation.name,
                Size = dropletInformation.size_slug,
                Region = "",
                Image = "",
                SshKey = new List<string>()

            };
            return vmData;
        }
    }
}
