using System;
using System.Collections.Generic;

namespace Phenotype.Models
{
    public class GenotypeItem
    {
        public Guid FId { get; set; }
        public Guid MId { get; set; }
    }

    public class ReportParams
    {
        public List<GenotypeItem> Params { get; set; }
    }
}