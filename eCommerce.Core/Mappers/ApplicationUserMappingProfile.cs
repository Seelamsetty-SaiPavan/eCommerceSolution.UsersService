﻿using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eCommerce.Core.Mappers;

public class ApplicationUserMappingProfile : Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
          .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
          .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
          .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
          .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
          .ForMember(dest => dest.Success, opt => opt.Ignore())
          .ForMember(dest => dest.Token, opt => opt.Ignore())
          ;

        // Mapping from RegisterRequest DTO to ApplicationUser entity
        //CreateMap<RegisterRequest, ApplicationUser>()
        //    .ForMember(dest => dest.UserID, opt => opt.Ignore()) // UserID is usually generated, so we ignore it
        //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
        //    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password)) // Consider hashing the password separately
        //    .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
        //    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender)); // Convert enum to string
    }
}