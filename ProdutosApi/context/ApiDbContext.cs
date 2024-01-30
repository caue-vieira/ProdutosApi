using Microsoft.EntityFrameworkCore;
using ProdutosApi.models;

namespace ProdutosApi.context;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    { }

    public DbSet<ProdutoModel> Produtos { get; set; }
    public DbSet<CategoriaModel> Categorias { get; set; }
    public DbSet<UsuarioModel> Usuarios { get; set; }
}
