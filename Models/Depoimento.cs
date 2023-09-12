using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoViagens.Models;

public class Depoimento
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Foto { get; set; }
    public string Comentario { get; set; }
    public string AutorComentario { get; set; }
}
