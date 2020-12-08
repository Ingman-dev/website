using IngmanDevelopment.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngmanDevelopment.Models.ViewModels
{
    public class SummaryViewModel
    {
        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }
        public int NewDeaths { get; set; }
        public int TotalDeaths { get; set; }
        public int NewRecovered { get; set; }
        public int TotalRecovered { get; set; }
        public DateTime Date { get; set; }

        private List<Country> countries;


        public string SelectedCountry { get; set; }
        public IEnumerable<SelectListItem> Countries
        {
            get
            {
                if(countries != null)
                {
                    return countries.Select(x =>
                    new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Name
                    });
                }
                return null;
            }
        }

        public SummaryViewModel(CountryDTO country, SummaryDetailDTO summaryDetail)
        {

        }
    }
}
