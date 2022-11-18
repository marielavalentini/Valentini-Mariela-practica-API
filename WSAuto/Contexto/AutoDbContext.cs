using Microsoft.EntityFrameworkCore;
using WSAuto.Models;

namespace WSAuto.Contexto
{
    public class AutoDbContext : DbContext
    {
        public AutoDbContext(DbContextOptions<AutoDbContext> options) : base(options) { }

        public DbSet<Auto> Autos { get; set; }
    }
}
