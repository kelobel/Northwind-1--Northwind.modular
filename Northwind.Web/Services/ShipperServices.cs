﻿using Newtonsoft.Json;
using Northwind.Web.IServices;
using Northwind.Web.Models;
using Northwind.Web.Results;
using Northwind.Web.Result.ShippersResult;

public class ShipperServices : IShippersServices
{
    private readonly HttpClient _httpClient;

    public ShipperServices(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
    }

    public async Task<ShippersGetListResult> GetShippersAsync()
    {
        var response = await _httpClient.GetAsync("http://localhost:5223/api/Shippers/GetShippers");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<ShippersGetListResult>(apiResponse);
    }

    public async Task<ShipperGetResult> GetShipperByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"http://localhost:5223/api/Shippers/GetShipperById?id={id}");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<ShipperGetResult>(apiResponse);
    }

    public async Task<BaseResult> CreateShipperAsync(ShippersBaseModel shipper)
    {
        var jsonContent = JsonConvert.SerializeObject(shipper);
        var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("http://localhost:5223/api/Shippers/SaveShippers", contentString);
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }

    public async Task<BaseResult> UpdateShipperAsync(int id, ShippersBaseModel shipper)
    {
        var jsonContent = JsonConvert.SerializeObject(shipper);
        var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"http://localhost:5223/api/Shippers/UpdateShipper?id={id}", contentString);
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }

    public async Task<BaseResult> DeleteShipperAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"http://localhost:5223/api/Shippers/DeleteShipper?id={id}");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }
}
