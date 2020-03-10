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
    [RoutePrefix("api/VehicleMake")]
    public class VehicleMakeController : ApiController
    {

        public VehicleMakeController(IVehicleMakeService service)
        {
            this.Service = service;
        }
        public IVehicleMakeService Service { get; private set; }

        [Route("GetVehicleMake")]
        [HttpGet]
        public async Task<List<VehicleMakeRestModel>> GetAllVehiclesMake(PaginateRestModel pagingParams)
        {
            PaginatedInputModel paginatedInput = Mapper.Map<PaginatedInputModel>(pagingParams);

            List<IVehicleMake> vehicleMake = await Service.GetAllVehiclesMake(paginatedInput);
            return (Mapper.Map<List<VehicleMakeRestModel>>(vehicleMake));

        }
        [Route("AddVehiclesMake")]
        [HttpPost]
        public async Task<HttpResponseMessage> SaveVehiclesMake(VehicleMakeRestModel vehicleMakeRestModel)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            bool res = false;

            if (vehicleMakeRestModel != null)
            {
                IVehicleMake vehicleMake = Mapper.Map<IVehicleMake>(vehicleMakeRestModel);

              

                res = await Service.SaveVehiclesMake(vehicleMake);

                if (res == true)
                {
                    var showMessage = "Vehicle Saved Successfully.";

                    dict.Add("Message", showMessage);
                    return Request.CreateResponse(HttpStatusCode.OK, dict);
                }
                else
                {
                    var showMessage = "Vehicle Not Saved Please try again.";

                    dict.Add("Message", showMessage);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, dict);

                }
            }
            else
            {
                var showMessage = "No Data Found.";

                dict.Add("Message", showMessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
            }
        }

        [Route("UpdateVehicleMake")]
        [HttpPost]
        public async Task<HttpResponseMessage> UpdateVehicleMake(VehicleMakeRestModel vehicleMakeRestModel)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            bool res = false;
            if (vehicleMakeRestModel != null)
            {

                IVehicleMake vehicleMake = Mapper.Map<IVehicleMake>(vehicleMakeRestModel);


                res = await Service.UpdateVehicleMake(vehicleMake);

                if (res == true)
                {
                    var showMessage = "Vehicle Updated Successfully.";

                    dict.Add("Message", showMessage);
                    return Request.CreateResponse(HttpStatusCode.OK, dict);
                }
                else
                {
                    var showMessage = "Vehicle Not Updated Please try again.";

                    dict.Add("Message", showMessage);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, dict);

                }
            }
            else
            {
                var showMessage = "No Data Found.";

                dict.Add("Message", showMessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
            }
        }

        [Route("DeleteVehicleMake")]
        [HttpPost]
        public async Task<HttpResponseMessage> DeleteVehicleMake(VehicleMakeRestModel vehicleMakeRestModel)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            bool res = false;
            if (vehicleMakeRestModel != null)
            {


                IVehicleMake vehicleMake = Mapper.Map<IVehicleMake>(vehicleMakeRestModel);


                res = await Service.DeleteVehicleMake(vehicleMake);

                if (res == true)
                {
                    var showMessage = "Vehicle Deleted Successfully.";

                    dict.Add("Message", showMessage);
                    return Request.CreateResponse(HttpStatusCode.OK, dict);
                }
                else
                {
                    var showMessage = "Vehicle Not Deleted Please try again.";

                    dict.Add("Message", showMessage);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, dict);

                }
            }
            else
            {
                var showMessage = "No Data Found.";

                dict.Add("Message", showMessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
            }
        }
    }
}
