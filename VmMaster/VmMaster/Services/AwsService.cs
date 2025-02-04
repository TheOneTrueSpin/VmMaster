using VmMaster.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VmMaster.Dtos.Post;
using VmMaster.Models;
using VmMaster.Classes;

namespace VmMaster.Services
{
    public class AwsService : ICloudService
    {
        public Task CreateVM(CreateVmDto vmDto)
        {
            throw new NotImplementedException();
        }
        public /*async*/ Task DestroyVM(int vmId)
        {
            Console.WriteLine("Destroyed VM on AWS");
            throw new NotImplementedException();
            
        }
        public /*async*/ Task RenameVM(string name, int vmId)
        {
            Console.WriteLine("Renamed VM on AWS");
            throw new NotImplementedException();
        }
        public void AwsSpeciality()
        {
            Console.WriteLine("a special service for aws");
        }
        public /*async*/ Task<List<VmData>> ListVM()
        {
            Console.WriteLine("List Vm on AWS");
            throw new NotImplementedException();
        }
        public /*async*/ Task<DropletSizesResponse> GetSizes()
        {
            Console.WriteLine("Show Vm sizes");
            throw new NotImplementedException();
        }
    }
}
