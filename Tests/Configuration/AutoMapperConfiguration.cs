using API.ViewModels;
using AutoMapper;
using Domain.Entities;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IMapper GetConfiguration()
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
            });
            return autoMapperConfig.CreateMapper();
        }
    }
}
