using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vehicle.Model.Common;
using Vehicle.Model;
using System.Collections.Generic;
using Vehicle.WebAPI.Controllers;
using System.Threading.Tasks;
using System.Net.Http;
using Vehicle.Common;
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Tests
{
    [TestClass]
   public abstract class VehicleModelWebAPITests
    {

        public abstract VehicleModelController GetInstance();

        [TestMethod]
        public void TestGetAllVehicles()
        {
            VehicleModelController vehicleController = GetInstance();
            PaginateRestModel pagingParams = new PaginateRestModel();
            pagingParams.FilterParam = null;
            pagingParams.SortingParams = null;
            pagingParams.PageNumber = 1;
            pagingParams.PageSize = 4;
            var testVehicles = GetTestVehicles();
            var result = vehicleController.GetAllVehiclesModel(pagingParams) as Task<List<VehicleModelRestModel>>;
            Assert.AreEqual(testVehicles.Count, 1);
        }

      

        [TestMethod]
        public void TestAddVehicle()
        {
            VehicleModelRestModel obj = new VehicleModelRestModel();
            obj.Id = 1;
            obj.MakeId = 3;
            obj.Name = "DemoName";
            obj.Abrv = "DemoAbrv";


            VehicleModelController vehicleController = GetInstance();

            var result = vehicleController.SaveVehiclesModel(obj) as Task<HttpResponseMessage>;
            Assert.AreEqual(true, true);
        }


        [TestMethod]
        public void TestUpdateVehicle()
        {
            VehicleModelRestModel obj = new VehicleModelRestModel();
            obj.MakeId = 3;
            obj.Name = "BMW";
            obj.Abrv = "SSD";


            VehicleModelController VehicleController = GetInstance();

            var result = VehicleController.UpdateVehicleModel(obj) as Task<HttpResponseMessage>;
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestDeleteVehicle()
        {

            VehicleModelController vehicleController = GetInstance();
            VehicleModelRestModel obj = new VehicleModelRestModel();
            obj.Id = 1;
            var result = vehicleController.DeleteVehicleModel(obj) as Task<HttpResponseMessage>;
            Assert.AreEqual(true, true);
        }
        
        private List<IVehicleModel> GetTestVehicles()
        {
            var lstVehicleModel = new List<IVehicleModel>();
            lstVehicleModel.Add(new VehicleModel { Id = 1, Name = "DemoName", MakeId = 1, Abrv = "DemoAbrv" });

            return lstVehicleModel;
        }
    }
}
