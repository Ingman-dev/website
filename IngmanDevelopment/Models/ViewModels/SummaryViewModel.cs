using IngmanDevelopment.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngmanDevelopment.Models.ViewModels
{
    public class SummaryViewModel
    {
        [Display(Name = "Nya Bekräftade fall")]
        [DisplayFormat(DataFormatString = "{0:N0} st")]
        public int NewConfirmed { get; set; }
        [Display(Name = "Totala antalet Bekräftade fall")]
        [DisplayFormat(DataFormatString = "{0:N0} st")]
        public int TotalConfirmed { get; set; }
        [Display(Name = "Nya Bekräftade döda")]
        [DisplayFormat(DataFormatString = "{0:N0} st")]
        public int NewDeaths { get; set; }
        [Display(Name = "Totala antalet Bekräftade döda")]
        [DisplayFormat(DataFormatString = "{0:N0} st")]
        public int TotalDeaths { get; set; }
        [Display(Name = "Nya Tillfrisknade")]
        [DisplayFormat(DataFormatString = "{0:N0} st")]
        public int NewRecovered { get; set; }
        [Display(Name = "Totala antalet tillfrisknade")]
        [DisplayFormat(DataFormatString = "{0:N0} st")]
        public int TotalRecovered { get; set; }
        [Display(Name = "Datum")]
        [DisplayFormat(DataFormatString ="{0:dddd dd MMMM}")]
        public DateTime Date { get; set; }

        private List<Country> countries;

        public string SelectedCountry { get; set; } = "Sweden"; // Sverige är defaultvärde.

        [Display(Name = "Välj land")]
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

        public SummaryViewModel(IEnumerable<CountryDTO> countries, SummaryDetailDTO summaryDetail)
        {
            //ger alla värden till våra properties
            NewConfirmed = summaryDetail.NewConfirmed;
            TotalConfirmed = summaryDetail.TotalConfirmed;
            NewDeaths = summaryDetail.NewDeaths;
            TotalDeaths = summaryDetail.TotalDeaths;
            NewRecovered = summaryDetail.NewRecovered;
            TotalRecovered = summaryDetail.TotalRecovered;
            Date = summaryDetail.Date;

            //gör om CountryDTO till en lista av countries
            this.countries = countries
                .Select(c => new Country
                {
                    Name = c.Country
                })
                .OrderBy(x => x.Name)
                .ToList();
        }

        public SummaryViewModel()
        {

        }
    }
}
