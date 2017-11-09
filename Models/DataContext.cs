using Microsoft.EntityFrameworkCore;

namespace Phenotype.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        public DbSet<Genotype> Genotypes { get; set; }
        public DbSet<PhenotypeResult> PhenotypeResults { get; set; }
    }
}