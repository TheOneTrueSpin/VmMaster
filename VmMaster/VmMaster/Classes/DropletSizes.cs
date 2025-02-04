using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace VmMaster.Classes
{
    public class DropletSizes
    {
        public required string slug { get; set; }
        public required int memory { get; set; }
        public required int vcpus { get; set; }
        public required int disk { get; set; }
        public required float transfer { get; set; }
        public required float price_monthly { get; set; }
        public required float price_hourly { get; set; }
        public required List<string> regions { get; set; }
        public required bool available { get; set; }
        public required string description { get; set; }
        
    }
}
