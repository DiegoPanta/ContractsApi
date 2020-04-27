using System.Threading.Tasks;
using ContractsApi.Models;
using ContratosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContratosApi.Data {
    public class DataContext : DbContext {

        public DataContext (DbContextOptions<DataContext> options):
            base (options) {

            }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Installment> Installments { get; set; }

        public virtual async Task<int> ExecuteSqlRawAsync (string sql, params object[] parameters) {
            return await Database.ExecuteSqlRawAsync (sql, parameters);
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Contract>().Map();
            modelBuilder.Entity<Installment>().Map();
        }
    }
}