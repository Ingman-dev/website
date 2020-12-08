using IngmanDevelopment.Models.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;

namespace IngmanDevelopment.Data
{
    public class CovidRepository : ICovidRepository
    {
        private string baseUrl;
        public CovidRepository(IConfiguration configuration)
        {
            baseUrl = configuration.GetValue<string>("CovidApi:BaseUrl");
        }

        public async Task <IEnumerable<CountryDTO>> GetCountries()
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseUrl}countries";
                var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<CountryDTO>>(data);
                return result;
            }
        }

        public async Task<SummaryDTO> GetSummary()
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseUrl}summary";
                var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<SummaryDTO>(data);
                return result;
            }
        }
    }
}
