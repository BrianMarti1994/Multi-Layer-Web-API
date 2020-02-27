using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vehicle.Model.Common;
using Vehicle.Model;
using System.Collections.Generic;
using Vehicle.WebAPI.Controllers;
using System.Threading.Tasks;
using System.Net.Http;
using Vehicle.Common;

namespace Vehicle.WebAPI.Tests
{
    [TestClass]
   public abstract class VehicleModelWebAPITests
    {

        public abstract VehicleModelController GetInstance();

        [TestMethod]
        public void TestGetAllVehicles()
        {
            VehicleModelController VehicleController = GetInstance();
            PaginatedInputModel pagingParams = new PaginatedInputModel();
            pagingParams.FilterParam = null;
            pagingParams.SortingParams = null;
            pagingParams.PageNumber = 1;
            pagingParams.PageSize = 4;
            var TestVehicles = GetTestVehicles();
            var result = VehicleController.GetAllVehiclesModel(pagingParams) as Task<List<IVehicleModel>>;
            Assert.AreEqual(TestVehicles.Count, 1);
        }

      

        [TestMethod]
        public void TestAddVehicle()
        {
            Vehicle.Model.VehicleModel obj = new Vehicle.Model.VehicleModel();
            obj.Id = 1;
            obj.MakeId = 3;
            obj.Name = "DemoName";
            obj.Abrv = "DemoAbrv";


            VehicleModelController VehicleController = GetInstance();

            var result = VehicleController.SaveVehiclesModel(obj) as Task<HttpResponseMessage>;
            Assert.AreEqual(true, true);
        }


        [TestMethod]
        public void TestUpdateVehicle()
        {
            Vehicle.Model.VehicleModel obj = new Vehicle.Model.VehicleModel();
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

            VehicleModelController VehicleController = GetInstance();
            VehicleModel obj = new VehicleModel();
            obj.Id = 1;
            var result = VehicleController.DeleteVehicleModel(obj) as Task<HttpResponseMessage>;
            Assert.AreEqual(true, true);
        }
        
        private List<IVehicleModel> GetTestVehicles()
        {
            var LstVehicleModel = new List<IVehicleModel>();
            LstVehicleModel.Add(new VehicleModel { Id = 1, Name = "DemoName", MakeId = 1, Abrv = "DemoAbrv" });

            return LstVehicleModel;
        }
    }
}
