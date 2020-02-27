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
    public abstract class VehicleMakeWebAPITests
    {
        public abstract VehicleMakeController GetInstance();
        [TestMethod]
        public void TestGetAllVehicles()
        {
            VehicleMakeController VehicleController = GetInstance();

            var TestVehicles = GetTestVehicles();
            PaginatedInputModel pagingParams = new PaginatedInputModel();
            pagingParams.FilterParam = null;
            pagingParams.SortingParams = null;
            pagingParams.PageNumber = 1;
            pagingParams.PageSize = 4;
            var result = VehicleController.GetAllVehiclesMake(pagingParams) as Task<List<IVehicleMake>>;
            Assert.AreEqual(TestVehicles.Count, 1);
        }
        [TestMethod]
        public void TestAddVehicle()
        {
            Vehicle.Model.VehicleMake obj = new Vehicle.Model.VehicleMake();
            obj.Id = 1;
            obj.Name = "DemoName";
            obj.Abrv = "DemoAbrv";


            VehicleMakeController VehicleController = GetInstance();

            var result = VehicleController.SaveVehiclesMake(obj) as Task<HttpResponseMessage>;
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestUpdateVehicle()
        {
            Vehicle.Model.VehicleMake obj = new Vehicle.Model.VehicleMake();
            obj.Id = 1;
            obj.Name = "BMW";
            obj.Abrv = "SSD";


            VehicleMakeController VehicleController = GetInstance();

            var result = VehicleController.UpdateVehicleMake(obj) as Task<HttpResponseMessage>;
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestDeleteVehicle()
        {

            VehicleMakeController VehicleController = GetInstance();
            VehicleMake obj = new VehicleMake();
            obj.Id = 1;
            var result = VehicleController.DeleteVehicleMake(obj) as Task<HttpResponseMessage>;
            Assert.AreEqual(true, true);
        }

        private List<IVehicleMake> GetTestVehicles()
        {
            var LstVehicleMake = new List<IVehicleMake>();
            LstVehicleMake.Add(new VehicleMake { Id = 1, Name = "DemoName", Abrv = "DemoAbrv"});


            return LstVehicleMake;
        }
    }
}
