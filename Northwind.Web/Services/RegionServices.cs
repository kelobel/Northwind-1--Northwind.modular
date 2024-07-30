using Newtonsoft.Json;
using Northwind.Web.IServices;
using Northwind.Web.Models.RegionModels;
using Northwind.Web.Results;
using Northwind.Web.Results.Region_Results;
namespace Northwind.Web.Services
{
    public class RegionServices : IRegionServices
    {
        private readonly HttpClient _httpClient;


        public RegionServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
        }

        public async Task<RegionGetListResult> GetRegionAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5223/api/Region/GetRegions\n");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RegionGetListResult>(apiResponse);
        }


        public async Task<RegionGetResult> GetRegionByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5223/api/Region/GetRegionById?id={id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RegionGetResult>(apiResponse);
        }

        public async Task<BaseResult> CreateRegionAsync(RegionGetModel region)
        {
            var jsonContent = JsonConvert.SerializeObject(region);
            var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response =
                await _httpClient.PostAsync("http://localhost:5223/api/Region/SaveRegion\n", contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }

        public async Task<BaseResult> UpdateRegionAsync(int id, RegionGetModel region)
        {
            var jsonContent = JsonConvert.SerializeObject(region);
            var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"http://localhost:5223/api/Region/UpdateRegion?id={id}",
                contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }

        public async Task<BaseResult> DeleteRegionAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5223/api/Region/RemoveRegion?id={id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }
    }
}
