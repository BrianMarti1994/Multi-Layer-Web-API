using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model.Common;

namespace Vehicle.Model.Common
{
   public interface IVehicleModel
    {
         int Id { get; set; }
         int MakeId { get; set; }
         string Name { get; set; }
         string Abrv { get; set; }
        //IVehicleMake VehicleMake { get; set; }
    }
}
