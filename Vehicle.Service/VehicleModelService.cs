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
        VehicleModel ObjVech = new VehicleModel();
        protected IVehicleModelRepository Repository { get; private set; }
        public VehicleModelService(IVehicleModelRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("IVehicleModelRepository", "Repository is Null");
            }
            this.Repository = repository;
        }

        public async Task<List<IVehicleModel>> GetAllVehiclesModel(PaginatedInputModel pagingParams)
        {
            return await Repository.GetAllVehiclesModel(pagingParams);

        }

        public async Task<bool> SaveVehiclesModel(IVehicleModel ObjVechicle)
        {
            ObjVech.Id = ObjVechicle.Id;
            ObjVech.MakeId = ObjVechicle.MakeId;
            ObjVech.Name = ObjVechicle.Name;
            ObjVech.Abrv = ObjVechicle.Abrv;
            return await Repository.SaveVehiclesModel(ObjVech);
        }
        public async Task<bool> UpdateVehicleModel(IVehicleModel ObjVechicle)
        {
            ObjVech.Id = ObjVechicle.Id;
            ObjVech.MakeId = ObjVechicle.MakeId;
            ObjVech.Name = ObjVechicle.Name;
            ObjVech.Abrv = ObjVechicle.Abrv;
            return await Repository.UpdateVehicleModel(ObjVech);
        }

        public async Task<bool> DeleteVehicleModel(IVehicleModel ObjVechicle)
        {
            ObjVech.Id = ObjVechicle.Id;
            return await Repository.DeleteVehicleModel(ObjVech);
        }

    }
}
