using Application.DTOs.UserProfile;
using AutoMapper;
using Domain;

namespace Application.Profiles;

public class UserProfileMapProfile : Profile 
{
   public UserProfileMapProfile()
   {
      CreateMap<UserProfileDto, UserProfile>();
   }
}