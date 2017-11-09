using System;

namespace Phenotype.Models
{
    public class PhenotypeResult
    {
        public Guid Id { get; set; }
        public Guid FatherId { get; set; }
        public virtual Genotype Father { get; set; }
        public Guid MotherId { get; set; }
        public virtual Genotype Mother { get; set; }
        public Double Probability { get; set; }
        public string Result { get; set; }
    }
}