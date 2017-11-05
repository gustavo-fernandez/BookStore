using AutoMapper;
using BusinessLogicApi.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicImpl.Mapper
{
    public class MapperConfig
    {
        private MapperConfig() { }

        internal static IMapper MapperInstance { get; private set; }

        static MapperConfig()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, CreatedUser>();
            });
            MapperConfig.MapperInstance = new AutoMapper.Mapper(config);
        }
    }
}
