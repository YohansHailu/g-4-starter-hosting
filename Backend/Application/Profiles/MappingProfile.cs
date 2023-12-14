using Application.DTOs.Rating;
using AutoMapper;
using Domain;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        
         public MappingProfile()
         {
            CreateMap<Rating, RatingDto>().ReverseMap();

         }
    }
}