using VmMaster.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VmMaster.Services
{
    public class DigitalOceanService : ICloudService
    {
        public void CreateVM()
        {
            Console.WriteLine("Created VM on Digital Ocean");
        }
        public void DestroyVM()
        {
            Console.WriteLine("Destroyed VM on Digital Ocean");
        }
        public void RenameVM(string name)
        {
            Console.WriteLine("Renamed VM on Digital Ocean");
        }
    }
}

