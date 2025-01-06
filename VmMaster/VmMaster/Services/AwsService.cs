using VmMaster.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VmMaster.Services
{
    public class AwsService : ICloudService
    {
        public void CreateVM()
        {
            Console.WriteLine("Created VM on AWS");
        }
        public void DestroyVM()
        {
            Console.WriteLine("Destroyed VM on AWS");
        }
        public void RenameVM(string name)
        {
            Console.WriteLine("Renamed VM on AWS");
        }
        public void AwsSpeciality()
        {
            Console.WriteLine("a special service for aws");
        }
    }
}
