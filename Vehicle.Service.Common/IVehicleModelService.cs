using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Model.Common;
namespace Vehicle.Service.Common
{
    public interface IVehicleModelService
    {
        Task<List<VehicleModel>> GetAllVehiclesModel(PaginatedInputModel pagingParams);

        Task<bool> SaveVehiclesModel(IVehicleModel vehicleModel);

        Task<bool> UpdateVehicleModel(IVehicleModel vehicleModel);

        Task<bool> DeleteVehicleModel(IVehicleModel vehicleModel);
    }
}
