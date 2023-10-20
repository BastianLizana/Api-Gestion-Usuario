using Microsoft.EntityFrameworkCore;

namespace Api_Gestion_Clientes.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Clientes> Cliente => Set<Clientes>();
        public DbSet<Logging> Log => Set<Logging>();
    }
}
