using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebExperience.Test.Dtos;
using WebExperience.Test.Models;

namespace WebExperience.Test.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Asset, AssetDto>();
            Mapper.CreateMap<AssetDto, Asset>();
        }
    }
}