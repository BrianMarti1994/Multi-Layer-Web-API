using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model.Common;
using Dapper.Contrib.Extensions;
namespace Vehicle.Model
{
  [KnownType(typeof(VehicleMake))]
    public class VehicleMake:IVehicleMake
    {   [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
      
        
    }
}
