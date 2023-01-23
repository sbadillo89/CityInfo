using System;
using System.Data;
using AutoMapper;
using CityInfo.Dtos;
using CityInfo.Models;

namespace CityInfo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDTO>()
                .ForMember(dest => dest.Code,
                           opt => opt.MapFrom(src => src.Iso2))
                .ReverseMap();

            CreateMap<History, HistoryDTO>()
                .ReverseMap();

            CreateMap<History, HistoryCreateDTO>()
                .ReverseMap();
        }
    }
}

