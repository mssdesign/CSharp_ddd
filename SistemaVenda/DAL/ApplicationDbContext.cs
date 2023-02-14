using Microsoft.EntityFrameworkCore;
using SistemaVenda.Entidades;

namespace SistemaVenda.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<VendaProdutos> VendaProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<VendaProdutos>().HasKey(col => new { col.CodigoVenda, col.CodigoProduto });

            builder.Entity<VendaProdutos>()
                .HasOne(col => col.Venda)
                .WithMany(el => el.Produtos)
                .HasForeignKey(col => col.CodigoVenda);

            builder.Entity<VendaProdutos>()
                .HasOne(col => col.Produto)
                .WithMany(el => el.Vendas)
                .HasForeignKey(col => col.CodigoProduto);
        }
    }
}
