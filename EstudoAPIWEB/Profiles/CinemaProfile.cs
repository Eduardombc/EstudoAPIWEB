using AutoMapper;
using EstudoAPIWEB.Data.DTOs;
using EstudoAPIWEB.Models;

namespace EstudoAPIWEB.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<UpdateCinemaDTO, Cinema>();
        CreateMap<CreateCinemaDTO, Cinema>();
        CreateMap<Cinema, ReadCinemaDTO>();
    }
}
