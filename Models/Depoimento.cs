using System.ComponentModel.DataAnnotations;

namespace GerenciamentoViagens.Models;

public class Depoimento
{
    [Key]
    public int Id { get; set; }
    public string Foto { get; set; }
    public string Comentario { get; set; }
    public string AutorComentario { get; set; }
}
