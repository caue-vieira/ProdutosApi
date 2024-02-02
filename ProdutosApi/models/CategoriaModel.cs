using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProdutosApi.models;

[Table("Categorias")]
public class CategoriaModel
{
    public CategoriaModel()
    {
        Produtos = new Collection<ProdutoModel>();
    }
    [Key]
    public int CategoriaId { get; set; }
    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }
    [JsonIgnore]
    public ICollection<ProdutoModel>? Produtos { get; set; }
}
