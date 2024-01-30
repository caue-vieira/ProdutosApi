using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProdutosApi.models;

[Table("Produtos")]
public class ProdutoModel
{
    [Key]
    public int ProdutoId { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? Descricao { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImgUrl { get; set; }

    [Required]
    public int Estoque { get; set; }

    public int CategoriaId { get; set; }

    [JsonIgnore]
    public CategoriaModel? Categoria { get; set; }
}
