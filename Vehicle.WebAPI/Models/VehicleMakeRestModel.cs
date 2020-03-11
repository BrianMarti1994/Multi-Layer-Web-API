using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model.Common;

namespace Vehicle.WebAPI.Models
{

   
    public class VehicleMakeRestModel
    {  
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public virtual ICollection<VehicleModelRestModel> vehicleModels { get; set; }
    }
}
