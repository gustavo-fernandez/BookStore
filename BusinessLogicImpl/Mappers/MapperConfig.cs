using AutoMapper;
using BusinessLogicApi.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicImpl.Mappers
{
    public class MapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, CreatedUser>();
            });
        }
    }
}
