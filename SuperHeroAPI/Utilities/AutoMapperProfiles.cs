using AutoMapper;
using SuperHeroAPI.DTOs;
using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<SuperHero, SuperHeroDTO>().ReverseMap();
            CreateMap<CreateSuperHeroDTO, SuperHero>().ReverseMap();
            CreateMap<UpdateSuperHeroDTO, SuperHero>().ReverseMap();
        }

    }
}
