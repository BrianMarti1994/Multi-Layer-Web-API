using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vehicle.Model.Common;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

using Vehicle.Model;
using Vehicle.Common;
using AutoMapper;

namespace Vehicle.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
       
        protected IVehicleMakeRepository Repository { get; private set; }
        public VehicleMakeService(IVehicleMakeRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("IVehicleMakeRepository", "Repository is Null");
            }
            this.Repository = repository;
        }

        public async Task<List<IVehicleMake>> GetAllVehiclesMake(PaginatedInputModel pagingParams)
        {
            return await Repository.GetAllVehiclesMake(pagingParams);

        }
        public async Task<bool> SaveVehiclesMake(IVehicleMake vehicleMakeService)
        {
            VehicleMake vehicleMake = Mapper.Map<VehicleMake>(vehicleMakeService);
            return await Repository.SaveVehiclesMake(vehicleMake);
        }



        public async Task<bool> UpdateVehicleMake(IVehicleMake ObjVech)
        {
            VehicleMake vehicleMake = Mapper.Map<VehicleMake>(ObjVech);

            return await Repository.UpdateVehicleMake(vehicleMake);
        }

        public async Task<bool> DeleteVehicleMake(IVehicleMake vehicleMakeService)
        {
            VehicleMake vehicleMake = Mapper.Map<VehicleMake>(vehicleMakeService);

            return await Repository.DeleteVehicleMake(vehicleMake);
        }
    }
}
