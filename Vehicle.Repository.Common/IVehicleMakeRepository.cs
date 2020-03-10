
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
    public interface IVehicleMakeRepository : IRepository<VehicleMake>
    {
        Task<List<IVehicleMake>> GetAllVehiclesMake(PaginatedInputModel pagingParams);

        Task<bool> SaveVehiclesMake(VehicleMake vehicleMake);

        Task<bool> UpdateVehicleMake(VehicleMake vehicleMake);

        Task<bool> DeleteVehicleMake(VehicleMake vehicleMake);
    }
}
