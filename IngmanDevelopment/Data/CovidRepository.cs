using IngmanDevelopment.Models.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using IngmanDevelopment.Models.ViewModels;
using IngmanDevelopment.Infrastructure;

namespace IngmanDevelopment.Data
{
    public class CovidRepository : ICovidRepository
    {
        private string baseUrl, defaultCountry;
        IApiClient apiClient;
        public CovidRepository(IConfiguration configuration, IApiClient apiClient)
        {
            baseUrl = configuration.GetValue<string>("CovidApi:BaseUrl");
            defaultCountry = configuration.GetValue<string>("CovidApi:DefaultCountry");
            this.apiClient = apiClient;
        }

        public async Task<IEnumerable<CountryDTO>> GetCountries()
        {
            return await apiClient.GetAsync<IEnumerable<CountryDTO>>(baseUrl + "countries");
        }

        public async Task<SummaryDTO> GetSummary()
        {
            return await apiClient.GetAsync<SummaryDTO>(baseUrl + "summary");
        }

        public async Task<SummaryViewModel> GetSummaryViewModel(string country = null)
        {
            country = country ?? defaultCountry;
            var tasks = new List<Task>(); // en lista med olika trådar

            var countries =  apiClient.GetAsync<IEnumerable<CountryDTO>>(baseUrl + "countries"); // ett nytt uppdrag
            var summary = apiClient.GetAsync<SummaryDTO>(baseUrl + "summary"); // ännu ett uppdrag

            tasks.Add(countries); // koppla ihop uppdraget med trådarna
            tasks.Add(summary);
            await Task.WhenAll(tasks); // kör alla trådar, parallellt

            SummaryDetailDTO summaryDetail = summary.Result.Countries
                .Where(c => c.Country.Equals(country))
                .FirstOrDefault();
            return new SummaryViewModel(countries.Result, summaryDetail);
        }

        public Task<IEnumerable<CountryDTO>> GetSummaryViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
