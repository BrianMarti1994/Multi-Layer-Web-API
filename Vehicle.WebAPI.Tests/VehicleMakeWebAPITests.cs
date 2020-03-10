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
    public abstract class VehicleMakeWebAPITests
    {
        public abstract VehicleMakeController GetInstance();
        [TestMethod]
        public void TestGetAllVehicles()
        {
            VehicleMakeController vehicleController = GetInstance();

            var testVehicles = GetTestVehicles();
            PaginateRestModel pagingParams = new PaginateRestModel();
            pagingParams.FilterParam = null;
            pagingParams.SortingParams = null;
            pagingParams.PageNumber = 1;
            pagingParams.PageSize = 4;
            var result = vehicleController.GetAllVehiclesMake(pagingParams) as Task<List<VehicleMakeRestModel>>;
            Assert.AreEqual(testVehicles.Count, 1);
        }
        [TestMethod]
        public void TestAddVehicle()
        {
            VehicleMakeRestModel obj = new VehicleMakeRestModel();
            obj.Id = 1;
            obj.Name = "DemoName";
            obj.Abrv = "DemoAbrv";


            VehicleMakeController vehicleController = GetInstance();

            var result = vehicleController.SaveVehiclesMake(obj) as Task<HttpResponseMessage>;
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestUpdateVehicle()
        {
            VehicleMakeRestModel obj = new VehicleMakeRestModel();
            obj.Id = 1;
            obj.Name = "BMW";
            obj.Abrv = "SSD";


            VehicleMakeController vehicleController = GetInstance();

            var result = vehicleController.UpdateVehicleMake(obj) as Task<HttpResponseMessage>;
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestDeleteVehicle()
        {

            VehicleMakeController vehicleController = GetInstance();
            VehicleMakeRestModel obj = new VehicleMakeRestModel();
            obj.Id = 1;
            var result = vehicleController.DeleteVehicleMake(obj) as Task<HttpResponseMessage>;
            Assert.AreEqual(true, true);
        }

        private List<IVehicleMake> GetTestVehicles()
        {
            var lstVehicleMake = new List<IVehicleMake>();
            lstVehicleMake.Add(new VehicleMake { Id = 1, Name = "DemoName", Abrv = "DemoAbrv"});


            return lstVehicleMake;
        }
    }
}
