using Microsoft.EntityFrameworkCore;
using GerenciadorDeEstoque;
using System.Reflection;
using Sistema_de_Gerenciamento_de_Estoques.Infra.Mappings;

namespace Sistema_de_Gerenciamento_de_Estoques.Infra.Context
{
    public class ManagerContext : DbContext
    {
        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=localhost;database=gerenciadordeestoque;uid=root";
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
    }

}
