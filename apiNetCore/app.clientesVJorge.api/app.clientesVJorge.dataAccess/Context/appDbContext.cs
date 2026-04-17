using app.clientesVJorge.entities.Models;
using Microsoft.EntityFrameworkCore;

namespace app.clientesVJorge.dataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DireccionCliente> DireccionClientes { get; set; }

    }
}