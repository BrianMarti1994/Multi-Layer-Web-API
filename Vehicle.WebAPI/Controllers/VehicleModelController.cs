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
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Controllers
{
    [RoutePrefix("api/VehicleModel")]
    public class VehicleModelController : ApiController
    {
        VehicleModel ObjVehMod = new VehicleModel();
        public VehicleModelController(IVehicleModelService service)
        {
            this.Service = service;
        }
        public IVehicleModelService Service { get; private set; }

        [Route("GetVehiclesModel")]
        [HttpGet]
        public async Task<List<IVehicleModel>> GetAllVehiclesModel(PaginatedInputModel pagingParams)
        {
            List<IVehicleModel> obj = await Service.GetAllVehiclesModel(pagingParams);
            return (Mapper.Map<List<IVehicleModel>>(obj));

            
        }
        [Route("AddVehicleModel")]
        [HttpPost]
        public async Task<HttpResponseMessage> SaveVehiclesModel(VehicleModelRestModel ObjVeh)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            bool res = false;
            if (ObjVeh != null)
            {


                VehicleModel IObjVehMod = Mapper.Map<VehicleModel>(ObjVeh);

                res = await Service.SaveVehiclesModel(IObjVehMod);

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

        [Route("UpdateVehicleModel")]
        [HttpPost]
        public async Task<HttpResponseMessage> UpdateVehicleModel(VehicleModelRestModel ObjVeh)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            bool res = false;
            if (ObjVeh != null)
            {


                VehicleModel IObjVehMod = Mapper.Map<VehicleModel>(ObjVeh);

                res = await Service.UpdateVehicleModel(IObjVehMod);

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

        [Route("DeleteVehicleModel")]
        [HttpPost]
        public async Task<HttpResponseMessage> DeleteVehicleModel(VehicleModelRestModel ObjVeh)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            bool res = false;
            if (ObjVeh != null)
            {


                VehicleModel IObjVehMod = Mapper.Map<VehicleModel>(ObjVeh);

                res = await Service.DeleteVehicleModel(IObjVehMod);

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
