using VmMaster.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VmMaster.Dtos.Post;

namespace VmMaster.Services
{
    public class AwsService : ICloudService
    {
        public Task CreateVM(CreateVmDto vmDto)
        {
            throw new NotImplementedException();
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
        public Task ListVM()
        {
            Console.WriteLine("List Vm on AWS");
        }
    }
}
