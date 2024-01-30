using System.ComponentModel.DataAnnotations;

namespace ProdutosApi.models;

public class UsuarioModel
{
    [Key]
    public int UsuarioId { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(80)]
    public string? NomeUsu { get; set; }

    [Required]
    [StringLength(100)]
    public string? Email { get; set; }

    [Required]
    [StringLength(200)]
    public string? Senha { get; set; }

    [Required]
    [StringLength(200)]
    public string? ConfirmaSenha { get; set; }

    [StringLength(15)]
    public string? TipoUsuario { get; set;}
}
