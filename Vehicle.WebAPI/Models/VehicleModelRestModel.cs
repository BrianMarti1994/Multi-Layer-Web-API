using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Vehicle.WebAPI.Models
{

   
    public class VehicleModelRestModel
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public virtual VehicleMakeRestModel vehicleMake { get; set; }
    }
}