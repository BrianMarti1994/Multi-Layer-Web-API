using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Repository.Common;

namespace Vehicle.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IVehicleMakeRepository VehicleMakes { get; }
        IVehicleModelRepository VehicleModels { get; }
        int Save();
    }
}
