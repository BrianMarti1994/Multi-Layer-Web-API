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

namespace Vehicle.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        VehicleMake ObjVechicle = new VehicleMake();
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

            //return  Mapper.Map<List<IVehicleMake>>(data);
        }
        public async Task<bool> SaveVehiclesMake(IVehicleMake ObjVech)
        {
         
            ObjVechicle.Id = ObjVech.Id;
            ObjVechicle.Name = ObjVech.Name;
            ObjVechicle.Abrv = ObjVech.Abrv;

            return await Repository.SaveVehiclesMake(ObjVechicle);
        }
        public async Task<bool> UpdateVehicleMake(IVehicleMake ObjVech)
        {
            ObjVechicle.Id = ObjVech.Id;
            ObjVechicle.Name = ObjVech.Name;
            ObjVechicle.Abrv = ObjVech.Abrv;

            return await Repository.UpdateVehicleMake(ObjVechicle);
        }

        public async Task<bool> DeleteVehicleMake(IVehicleMake ObjVech)
        {
            ObjVechicle.Id = ObjVech.Id;
            
            return await Repository.DeleteVehicleMake(ObjVechicle);
        }
    }
}
