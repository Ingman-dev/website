using IngmanDevelopment.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngmanDevelopment.Models.ViewModels
{
    public class SummaryViewModel
    {
        public string Country { get; set; }
        public int NewConfirmed { get; set; }

        public SummaryViewModel(SummaryDTO summary)
        {
            NewConfirmed = summary.Global.NewConfirmed;
        }
    }
}
