using AutoMapper;
using GerenciamentoViagens.Data.Dto;
using GerenciamentoViagens.Models;

namespace GerenciamentoViagens.Profiles;

public class DestinoProfile : Profile
{
    public DestinoProfile()
    {
        CreateMap<CriarDestinoDto, Destino>();
        CreateMap<Destino, LerDestinoDto>();
        CreateMap<Destino, LerDestinoNomeDto>();
    }
}
