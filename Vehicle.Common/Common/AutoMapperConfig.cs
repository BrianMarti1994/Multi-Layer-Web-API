using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.WebAPI.Models;

namespace Vehicle.Common.Common
{
    public class AutoMapperConfig 
        //: IAutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(config => {
                AutoMapper.Mapper.CreateMap<Vehicle.DAL.VehicleMake, Vehicle.Model.VehicleMake>().ReverseMap();
                AutoMapper.Mapper.CreateMap<Vehicle.DAL.VehicleMake, Vehicle.Model.Common.IVehicleMake>().ReverseMap();
                AutoMapper.Mapper.CreateMap<Vehicle.Model.Common.IVehicleMake, Vehicle.Model.VehicleMake>().ReverseMap();
                AutoMapper.Mapper.CreateMap<VehicleMakeRestModel, Vehicle.Model.VehicleMake>().ReverseMap();
                AutoMapper.Mapper.CreateMap<Vehicle.Model.Common.IVehicleMake, VehicleMakeRestModel>().ReverseMap();
                AutoMapper.Mapper.CreateMap<PaginateRestModel, PaginatedInputModel>().ReverseMap();
                AutoMapper.Mapper.CreateMap<SortingParams, Vehicle.WebAPI.Models.SortingParams>().ReverseMap();
                AutoMapper.Mapper.CreateMap<FilterParams, Vehicle.WebAPI.Models.FilterParams>().ReverseMap();



                AutoMapper.Mapper.CreateMap<Vehicle.DAL.VehicleModel, Vehicle.Model.VehicleModel>().ReverseMap();
                AutoMapper.Mapper.CreateMap<Vehicle.DAL.VehicleModel, Vehicle.Model.Common.IVehicleModel>().ReverseMap();
                AutoMapper.Mapper.CreateMap<Vehicle.Model.Common.IVehicleModel, Vehicle.Model.VehicleModel>().ReverseMap();
                AutoMapper.Mapper.CreateMap<VehicleModelRestModel, Vehicle.Model.VehicleModel>().ReverseMap();
                AutoMapper.Mapper.CreateMap<Vehicle.Model.Common.IVehicleModel, VehicleModelRestModel>().ReverseMap();

                AutoMapper.Mapper.CreateMap<Vehicle.DAL.VehicleMake, Vehicle.Model.Common.IVehicleModel>().ReverseMap();

            });
        }
    }
}
