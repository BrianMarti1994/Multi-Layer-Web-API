using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Model.Common;

namespace Vehicle.Repository.Common
{
   public interface IVehicleModelRepository : IRepository<VehicleModel>
    {

        Task<List<IVehicleModel>> GetAllVehiclesModel(PaginatedInputModel pagingParams);

        Task<bool> SaveVehiclesModel(VehicleModel ObjVechicle);

        Task<bool> UpdateVehicleModel(VehicleModel ObjVechicle);

        Task<bool> DeleteVehicleModel(VehicleModel ObjVechicle);
    }
}
