using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Service.Common;


namespace Vehicle.WebAPI.Controllers
{
    [RoutePrefix("api/VehicleMake")]
    public class VehicleMakeController : ApiController
    {
        VehicleMake ObjVehMak = new VehicleMake();
        public VehicleMakeController(IVehicleMakeService service)
        {
            this.Service = service;
        }
        public IVehicleMakeService Service { get; private set; }

        [Route("GetVehicleMake")]
        [HttpGet]
        public async Task<List<IVehicleMake>> GetAllVehiclesMake(PaginatedInputModel pagingParams)
       {

            return await Service.GetAllVehiclesMake( pagingParams);


        }
        [Route("AddVehiclesMake")]
        [HttpPost]
        public async Task<HttpResponseMessage> SaveVehiclesMake(VehicleMake ObjVeh)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            bool res = false;

            if (ObjVeh != null)
            {
                ObjVehMak = Mapper.Map<VehicleMake>(ObjVeh);

                res = await Service.SaveVehiclesMake(ObjVehMak);

                if (res == true)
                {
                    var showmessage = "Vehicle Saved Successfully.";

                    dict.Add("Message", showmessage);
                    return Request.CreateResponse(HttpStatusCode.OK, dict);
                }
                else
                {
                    var showmessage = "Vehicle Not Saved Please try again.";

                    dict.Add("Message", showmessage);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, dict);

                }
            }
            else
            {
                var showmessage = "No Data Found.";

                dict.Add("Message", showmessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
            }
        }

        [Route("UpdateVehicleMake")]
        [HttpPost]
        public async Task<HttpResponseMessage> UpdateVehicleMake(VehicleMake ObjVeh)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            bool res = false;
            if (ObjVeh != null)
            {
                
                ObjVehMak = Mapper.Map<VehicleMake>(ObjVeh);

                res = await Service.UpdateVehicleMake(ObjVehMak);

                if (res == true)
                {
                    var showmessage = "Vehicle Updated Successfully.";

                    dict.Add("Message", showmessage);
                    return Request.CreateResponse(HttpStatusCode.OK, dict);
                }
                else
                {
                    var showmessage = "Vehicle Not Updated Please try again.";

                    dict.Add("Message", showmessage);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, dict);

                }
            }
            else
            {
                var showmessage = "No Data Found.";

                dict.Add("Message", showmessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
            }
            }

        [Route("DeleteVehicleMake")]
        [HttpPost]
        public async Task<HttpResponseMessage> DeleteVehicleMake(VehicleMake ObjVeh)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            bool res = false;
            if (ObjVeh != null)
            {

           
            ObjVehMak = Mapper.Map<VehicleMake>(ObjVeh);

            res = await Service.DeleteVehicleMake(ObjVehMak);

            if (res == true)
            {
                var showmessage = "Vehicle Deleted Successfully.";

                dict.Add("Message", showmessage);
                return Request.CreateResponse(HttpStatusCode.OK, dict);
            }
            else
            {
                var showmessage = "Vehicle Not Deleted Please try again.";

                dict.Add("Message", showmessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);

            }
            }
            else
            {
                var showmessage = "No Data Found.";

                dict.Add("Message", showmessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
            }
        }
    }
}
