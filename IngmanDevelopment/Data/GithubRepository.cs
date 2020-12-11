using IngmanDevelopment.Models.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IngmanDevelopment.Data
{
    //public class GithubRepository : IGithubRepository
    //{
    //    private string baseUrlG;

    //    public GithubRepository(IConfiguration configuration)
    //    {
    //        baseUrlG = configuration.GetValue<string>("GithubAPI:BaseUrl2");
    //    }

    //    public async Task<IEnumerable<ReposDTO>> GetRepos()
    //    {
    //        using (HttpClient client = new HttpClient())
    //        {
    //            string endpoint = $"{baseUrlG}users/repos";
    //            var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
    //            response.EnsureSuccessStatusCode();
    //            var data = await response.Content.ReadAsStringAsync();
    //            var result = JsonConvert.DeserializeObject<IEnumerable<ReposDTO>>(data);
    //            return result;
    //        }
    //    }

    //    Task<IEnumerable<ReposDTO>> IGithubRepository.GetRepos()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
