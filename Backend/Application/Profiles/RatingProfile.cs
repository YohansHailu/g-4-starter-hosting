using Application.DTOs.Rating;
using AutoMapper;
using Domain;
using Application.DTOs.Comment;

namespace Application.Profiles
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<Rating, RatingDto>().ReverseMap();
            CreateMap<CreateRatingDto, RatingDto>();
            CreateMap<UpdateRatingInputModel, UpdateRatingDto>();
        }
    }
}
