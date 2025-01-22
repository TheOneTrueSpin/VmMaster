using VmMaster.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using VmMaster.Models.DigitalOceanModels;
using VmMaster.Models;
using VmMaster.Dtos.Post;
using Microsoft.AspNetCore.Http.HttpResults;

namespace VmMaster.Services
{
    public class DigitalOceanService : ICloudService
    {
        public async Task CreateVM(CreateVmDto vmDto)
        {
            string? apikey = Environment.GetEnvironmentVariable("DIGITALOCEAN_API_KEY");
            if (apikey is null)
            {
                throw new NullReferenceException();
            }
            Uri url = new Uri($"https://api.digitalocean.com/v2/droplets");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);
            CreateDroplet newDroplet = new CreateDroplet()
            {
                Name = vmDto.Name,
                Size = vmDto.Size,
                Image = vmDto.Image,
                SshKey = vmDto.SshKey
            };

            var response = await httpClient.PostAsJsonAsync(url, newDroplet);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("No response from client");
            }
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
        public async Task ListVM()
        {
            string? apikey = Environment.GetEnvironmentVariable("DIGITALOCEAN_API_KEY");
            if (apikey is null)
            {
                throw new NullReferenceException();
            }
            Uri url = new Uri($"https://api.digitalocean.com/v2/droplets");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);
            // needs await


        }
    }
}

