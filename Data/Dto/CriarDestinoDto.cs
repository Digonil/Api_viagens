using System.ComponentModel.DataAnnotations;

namespace GerenciamentoViagens.Data.Dto;

public class CriarDestinoDto
{
    public string Foto1 { get; set; }
    public string Foto2 { get; set; }
    public string Nome { get; set; }

    [StringLength(160)]
    public string Meta { get; set; }
    public string TextoDescritivo { get; set; }

}
