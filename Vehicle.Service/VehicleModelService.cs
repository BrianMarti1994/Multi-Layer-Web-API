using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        
        protected IVehicleModelRepository Repository { get; private set; }
        public VehicleModelService(IVehicleModelRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("IVehicleModelRepository", "Repository is Null");
            }
            this.Repository = repository;
        }

        public async Task<List<VehicleModel>> GetAllVehiclesModel(PaginatedInputModel pagingParams)
        {


            var vehicleModel = await Repository.GetAllVehiclesModel(pagingParams);
            return (Mapper.Map<List<VehicleModel>>(vehicleModel)); ;

        }

        public async Task<bool> SaveVehiclesModel(IVehicleModel vechicleModelService)
        {
            VehicleModel vehicleModel = Mapper.Map<VehicleModel>(vechicleModelService);
            return await Repository.SaveVehiclesModel(vehicleModel);
        }
        public async Task<bool> UpdateVehicleModel(IVehicleModel vechicleModelService)
        {
            VehicleModel vehicleModel = Mapper.Map<VehicleModel>(vechicleModelService);
            return await Repository.UpdateVehicleModel(vehicleModel);
        }

        public async Task<bool> DeleteVehicleModel(IVehicleModel vechicleModelService)
        {
            VehicleModel vehicleModel = Mapper.Map<VehicleModel>(vechicleModelService);
            return await Repository.DeleteVehicleModel(vehicleModel);
        }

    }
}
