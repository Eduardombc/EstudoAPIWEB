using AutoMapper;
using EstudoAPIWEB.Data.DTOs;
using EstudoAPIWEB.Models;

namespace EstudoAPIWEB.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<UpdateEnderecoDTO, Endereco>();
        CreateMap<CreateEnderecoDTO, Endereco>();
        CreateMap<Endereco, ReadEnderecoDTO>();
    }
}
