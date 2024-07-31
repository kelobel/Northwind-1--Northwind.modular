﻿using Newtonsoft.Json;
using Northwind.Web.IServices;
using Northwind.Web.Models;
using Northwind.Web.Result.ProductResult;
using Northwind.Web.Results;
using System.Text;

public class ProductServices : IProductsServices
{
    private readonly HttpClient _httpClient;

    public ProductServices(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
    }

    public async Task<ProductGetListResult> GetProductsAsync()
    {
        var response = await _httpClient.GetAsync("http://localhost:5223/api/Product/GetProducts");
        var apiResponse = await response.Content.ReadAsStringAsync();

        // Agregar log para la respuesta
        Console.WriteLine($"Response: {apiResponse}");

        response.EnsureSuccessStatusCode();
        return JsonConvert.DeserializeObject<ProductGetListResult>(apiResponse);
    }


    public async Task<ProductGetResult> GetProductByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"http://localhost:5223/api/Product/GetProductById?id={id}");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<ProductGetResult>(apiResponse);
    }

    public async Task<BaseResult> CreateProductAsync(ProductBaseModel product)
    {
        var jsonContent = JsonConvert.SerializeObject(product);
        var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("http://localhost:5223/api/Product/SaveProduct", contentString);
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }

    public async Task<BaseResult> UpdateProductAsync(int id, ProductBaseModel product)
    {
        var jsonContent = JsonConvert.SerializeObject(product);
        var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"http://localhost:5223/api/Product/UpdateProduct?id={id}", contentString);
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }

    public async Task<BaseResult> DeleteProductAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"http://localhost:5223/api/Product/DeleteProduct?id={id}");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }
}
