using Microsoft.EntityFrameworkCore;
using cryptoPayment.Models;


namespace cryptoPayment.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TransacoesCrypto> Transacoes { get; set; } // Tabela de transações

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Substitua pela string de conexão do seu SQL Server
            optionsBuilder
                .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BaseSoftshop9.14.1.0;User Id=sa;Password=qaz@123;TrustServerCertificate=True;");

        }

    }
}


