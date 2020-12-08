using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngmanDevelopment.Models.DTO
{
    public class SummaryDTO
    {
        public Global Global{ get; set; }
        public List<SummaryDetailDTO> Countries { get; set; }

    }

}
