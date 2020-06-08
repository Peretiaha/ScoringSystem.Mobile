using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ScoringSystem.Mobile.Models;
using Xamarin.Essentials;

namespace ScoringSystem.Mobile.Services
{
    public class MockDataStore : IDataStore<Customer>
    {
        IEnumerable<Customer> items;
        private readonly HttpClient client;

        public MockDataStore()
        {            
            client = new HttpClient { BaseAddress = new Uri($"{App.ApiURL}/") };
            items = new List<Customer>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;      
        
        public async Task<string> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) && !IsConnected)
                return string.Empty;
           
            var token = await client.GetStringAsync($"{ App.ApiURL}account/login/{email}/{password}");

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }

            return token;
        }

        public Task<bool> AddItemAsync(Customer item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Customer item)
        {
            throw new NotImplementedException();
        }

        Task<Customer> IDataStore<Customer>.GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Customer>> IDataStore<Customer>.GetItemsAsync(bool forceRefresh)
        {
            if (forceRefresh && IsConnected)
            {
                var users = await client.GetStringAsync($"https://fc86de9ba843.ngrok.io/api/account/all");

                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Customer>>(users));
            }

            return items;
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}