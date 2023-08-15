
using AccessControl.Dtos;
using AccessControl.Models;
using AutoMapper;

namespace AccessControl.Profiles;

public class ControleAcessoProfile : Profile
{
    public ControleAcessoProfile()
    {
        CreateMap<CreateAcessoDto, Acesso>();
        CreateMap<CreatePessoaDto, Pessoa>();
    }
}
