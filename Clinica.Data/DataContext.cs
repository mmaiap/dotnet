using Clinica.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Exame> Exames { get; set; }

    }
}
