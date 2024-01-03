using System.ComponentModel.DataAnnotations;

namespace GerenciamentoViagens.Models;

public class Destino
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Foto1 { get; set; }
    public string Foto2 { get; set; }
    public string Nome { get; set; }
    public string Meta { get; set; }
    public string TextoDescritivo { get; set; }
}
