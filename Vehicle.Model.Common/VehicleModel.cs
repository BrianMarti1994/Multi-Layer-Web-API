using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model.Common;

namespace Vehicle.Model
{
    [KnownType(typeof(VehicleModel))]
    public class VehicleModel: IVehicleModel
    {
        [Key]
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public virtual VehicleMake vehicleMake { get; set; }

    }
}
