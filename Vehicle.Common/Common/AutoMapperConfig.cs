using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Common.Common
{
    public class AutoMapperConfig : IAutoMapperConfig
    {
        public void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(config => {
                AutoMapper.Mapper.CreateMap<Vehicle.DAL.VehicleMake, Vehicle.Model.VehicleMake>().ReverseMap();
                AutoMapper.Mapper.CreateMap<Vehicle.DAL.VehicleMake, Vehicle.Model.Common.IVehicleMake>().ReverseMap();
                AutoMapper.Mapper.CreateMap<Vehicle.Model.Common.IVehicleMake, Vehicle.Model.VehicleMake>().ReverseMap();

                AutoMapper.Mapper.CreateMap<Vehicle.DAL.VehicleModel, Vehicle.Model.VehicleModel>().ReverseMap();
                AutoMapper.Mapper.CreateMap<Vehicle.DAL.VehicleModel, Vehicle.Model.Common.IVehicleModel>().ReverseMap();
                AutoMapper.Mapper.CreateMap<Vehicle.Model.Common.IVehicleModel, Vehicle.Model.VehicleModel>().ReverseMap();

            });
        }
    }
}
