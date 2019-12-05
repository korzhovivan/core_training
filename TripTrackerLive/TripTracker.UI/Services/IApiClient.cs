using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TripTracker.BackService.Models;

namespace TripTracker.UI.Services
{
    public interface IApiClient
    {
        Task<BackService.Models.Trip> GetTripAsync(int id);
        Task<List<BackService.Models.Trip>> GetTripsAsync();
    }
    public class ApiClient:IApiClient
    {
        private readonly HttpClient _HttpClient;

        public ApiClient(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        public async Task<Trip> GetTripAsync(int id)
        {
            var response = await _HttpClient.GetAsync($"/api/Trips/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsJsonAsync<Trip>();
        }

        public async Task<List<Trip>> GetTripsAsync()
        {
            var response = await _HttpClient.GetAsync("/api/Trips");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsJsonAsync<List<Trip>>();
        }
    }
}
