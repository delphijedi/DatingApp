using System.Linq;
using AutoMapper;
using DataingApp.API.Models;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListsDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url); 
                })
                .ForMember(src => src.Age, opt => {
                    opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                } );

            CreateMap<User, UserForDetailDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url); 
                })
                .ForMember(src => src.Age, opt => {
                    opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                } );

            CreateMap<Photo, PhotoForDetailDto>(); 
        }
    }
}