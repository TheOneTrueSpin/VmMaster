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
using System.Web;
using System.Text.Json;
using VmMaster.Classes;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task DestroyVM(int vmId)
        {
            string? apikey = Environment.GetEnvironmentVariable("DIGITALOCEAN_API_KEY");
            if (apikey is null)
            {
                throw new NullReferenceException();
            }
            Uri url = new Uri($"https://api.digitalocean.com/v2/droplets/{vmId}");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);
            var response = await httpClient.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("No response from client");
            }
            Console.WriteLine("Destroyed VM on Digital Ocean");
        }
        public async Task RenameVM(string newName, int vmId)
        {
            string? apikey = Environment.GetEnvironmentVariable("DIGITALOCEAN_API_KEY");
            if (apikey is null)
            {
                throw new NullReferenceException();
            }
            Uri url = new Uri($"https://api.digitalocean.com/v2/droplets/{vmId}/actions");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);
            DropletActionRename dropletActionRename = new DropletActionRename()
            {
                type = "rename",
                name = newName
            };

            var response = await httpClient.PostAsJsonAsync(url, dropletActionRename);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("No response from client");
            }
            Console.WriteLine("Renamed VM on Digital Ocean");
        }
        public async Task<List<VmData>> ListVM()
        {
            string? apikey = Environment.GetEnvironmentVariable("DIGITALOCEAN_API_KEY");
            if (apikey is null)
            {
                throw new NullReferenceException();
            }

            var query = HttpUtility.ParseQueryString(string.Empty);
            query.Add("arg1", "val1#@?$#");
            query.Add("arg2", "val2");
            query.Add("arg3", "val3");

            var url = new UriBuilder("https://api.digitalocean.com/v2/droplets")
            {
                Query = query.ToString()
            };
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);
            var response = await httpClient.GetAsync(url.Uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                
                DropletList? dropletList = JsonSerializer.Deserialize<DropletList>(content);
                if (dropletList is null)
                {
                    throw new Exception();
                }
                List<VmData> vmData = new List<VmData>
                {
                    
                };
                foreach (var droplet in dropletList.droplets)
                {
                    vmData.Add((VmData)droplet);
                }
                return vmData;
                
            }
            throw new Exception();


        }
        public async Task<DropletSizesResponse> GetSizes()
        {
            string? apikey = Environment.GetEnvironmentVariable("DIGITALOCEAN_API_KEY");
            if (apikey is null)
            {
                throw new NullReferenceException();
            }
            Uri url = new Uri($"https://api.digitalocean.com/v2/sizes");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                DropletSizesResponse? dropletSizesResponse = JsonSerializer.Deserialize<DropletSizesResponse>(content);
                if(dropletSizesResponse is null)
                {
                    throw new Exception();
                }
                return dropletSizesResponse;

            }
            throw new Exception();
        }
    }
}

