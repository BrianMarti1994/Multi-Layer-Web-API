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
       
        public VehicleModelController(IVehicleModelService service)
        {
            this.Service = service;
        }
        public IVehicleModelService Service { get; private set; }

        [Route("GetVehiclesModel")]
        [HttpGet]
        public async Task<List<VehicleModelRestModel>> GetAllVehiclesModel(PaginateRestModel pagingParams)
        {
            PaginatedInputModel paginatedInput = Mapper.Map<PaginatedInputModel>(pagingParams);
            
            List<IVehicleModel> vehicleModel = await Service.GetAllVehiclesModel(paginatedInput);
            return (Mapper.Map<List<VehicleModelRestModel>>(vehicleModel));

            
        }

        [Route("AddVehicleModel")]
        [HttpPost]
        public async Task<HttpResponseMessage> SaveVehiclesModel(VehicleModelRestModel vehicleRestModel)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            bool res = false;
            if (vehicleRestModel != null)
            {


                IVehicleModel vehicleModel = Mapper.Map<IVehicleModel>(vehicleRestModel);

                res = await Service.SaveVehiclesModel(vehicleModel);

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

        [Route("UpdateVehicleModel")]
        [HttpPost]
        public async Task<HttpResponseMessage> UpdateVehicleModel(VehicleModelRestModel vehicleRestModel)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            bool res = false;
            if (vehicleRestModel != null)
            {


                IVehicleModel vehicleModel = Mapper.Map<IVehicleModel>(vehicleRestModel);

                res = await Service.UpdateVehicleModel(vehicleModel);

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

        [Route("DeleteVehicleModel")]
        [HttpPost]
        public async Task<HttpResponseMessage> DeleteVehicleModel(VehicleModelRestModel vehicleRestModel)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            bool res = false;
            if (vehicleRestModel != null)
            {


                IVehicleModel vehicleModel = Mapper.Map<IVehicleModel>(vehicleRestModel);

                res = await Service.DeleteVehicleModel(vehicleModel);

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
