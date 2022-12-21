using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsersApiC.Models;
using UsersApiC.Dtos;

namespace UsersApiC.App_Start
{
    public class DtoMappingProfilecs : Profile
    {
        public DtoMappingProfilecs()
        {
            
            CreateMap<User, UserDto>();//il 1 viene mappato per essere convertito nel secondo
            CreateMap<User, UserDto>().ReverseMap();//qui per avere anche il mapping inverso
            CreateMap<Login, LoginDto>();
            CreateMap<Login, LoginDto>().ReverseMap();


        }
    }
}