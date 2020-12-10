using IngmanDevelopment.Models.DTO;
using IngmanDevelopment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngmanDevelopment.Data
{
    public interface ICovidRepository
    {
        Task<IEnumerable<CountryDTO>> GetCountries();
        Task<SummaryDTO> GetSummary();
        Task<SummaryViewModel> GetSummaryViewModel(string country = null);
        
    }
}
