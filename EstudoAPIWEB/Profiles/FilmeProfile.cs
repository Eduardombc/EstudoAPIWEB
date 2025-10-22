using AutoMapper;
using EstudoAPIWEB.Controllers;
using EstudoAPIWEB.Data.DTOs;

namespace EstudoAPIWEB.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDTO, Filme>();
        CreateMap<UpdateFilmeDTO, Filme>();
    }
}