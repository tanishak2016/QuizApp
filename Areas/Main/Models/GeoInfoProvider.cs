using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Quiz_App.Areas.Main.Models
{
    public class GeoInfoProvider
    {
        private readonly HttpClient _httpClient;
        //create constructor and call HttpClient
        public GeoInfoProvider()
        {
            _httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(5)
            };
        }

        //get public ip address
        private async Task<string> GetIPAddress()
        {
            var ipAddress = await _httpClient.GetAsync($"http://ipinfo.io/ip");
            if (ipAddress.IsSuccessStatusCode)
            {
                var json = await ipAddress.Content.ReadAsStringAsync();
                return json.ToString();
            }
            return "";
        }

        //get location based on IP address
        public async Task<GeoInfoViewModel> GetGeoInfo()
        {
            var model = new GeoInfoViewModel();
            var ipAddress = await GetIPAddress();

            // When geting ipaddress, call this function and pass ipaddress as given below
            var response = await _httpClient.GetAsync($"http://api.ipstack.com/" + ipAddress + "?access_key=fcf5851deaeb5f113747f876c55d6df0");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<GeoInfoViewModel>(json);
            }
            return model;
        }

    }
}
