using System.ComponentModel.DataAnnotations;

namespace GerenciamentoViagens.Models;

public class Destino
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Foto { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
}
