
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
   public interface IVehicleMakeService
    {
       
            Task<List<IVehicleMake>> GetAllVehiclesMake(PaginatedInputModel pagingParams);

            Task<bool> SaveVehiclesMake(IVehicleMake ObjVechicle);

            Task<bool> UpdateVehicleMake(IVehicleMake ObjVechicle);

            Task<bool> DeleteVehicleMake(IVehicleMake ObjVechicle);
        
    }
}
