using AutoMapper;
using GerenciamentoViagens.Data.Dto;
using GerenciamentoViagens.Models;

namespace GerenciamentoViagens.Profiles;

public class DepoimentoProfile : Profile
{
    public DepoimentoProfile()
    {
        CreateMap<CriarDepoimentoDto, Depoimento>();
        CreateMap<Depoimento, LerDepoimentoDto>();
    }
}
