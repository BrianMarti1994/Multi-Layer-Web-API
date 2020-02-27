using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vehicle.Service.Common;
using Vehicle.Model.Common;
using System.Collections.Generic;
using Vehicle.Model;
using Vehicle.Repository.Common;
using System.Threading.Tasks;
using Vehicle.Common;

namespace Vehicle.Service.Tests
{
    [TestClass]
    public abstract class VehicleMakeSeviceTests
    {
        public abstract IVehicleMakeService GetInstance();
        [TestMethod]
        public void TestGetAllVehicles()
        {

            IVehicleMakeService VehicleService = GetInstance();
            PaginatedInputModel pagingParams = new PaginatedInputModel();
            pagingParams.FilterParam = null;
            pagingParams.SortingParams = null;
            pagingParams.PageNumber = 1;
            pagingParams.PageSize = 4;
            var TestVehicles = GetTestVehicles();
            var result = VehicleService.GetAllVehiclesMake(pagingParams) as Task<List<IVehicleMake>>;
            Assert.AreEqual(TestVehicles.Count, 1);
        }

        [TestMethod]
        public void TestAddVehicle()
        {
            Vehicle.Model.VehicleMake obj = new Vehicle.Model.VehicleMake();
            obj.Id = 1;
            obj.Name = "DemoName";
            obj.Abrv = "DemoAbrv";


            IVehicleMakeService VehicleService = GetInstance();

            var result = VehicleService.SaveVehiclesMake(obj) as Task<bool>;
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestUpdateVehicle()
        {
            Vehicle.Model.VehicleMake obj = new Vehicle.Model.VehicleMake();
            obj.Id = 1;
            obj.Name = "BMW";
            obj.Abrv = "SSD";


            IVehicleMakeService VehicleService = GetInstance();

            var result = VehicleService.UpdateVehicleMake(obj) as Task<bool>;
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestDeleteVehicle()
        {

            IVehicleMakeService VehicleService = GetInstance();
            IVehicleMake obj = new VehicleMake();
            obj.Id = 1;
            var result = VehicleService.DeleteVehicleMake(obj) as Task<bool>;
            Assert.AreEqual(true, true);
        }

       
        
        private List<IVehicleMake> GetTestVehicles()
        {
            var LstVehicleMake = new List<IVehicleMake>();
            LstVehicleMake.Add(new VehicleMake { Id = 1, Name = "DemoName", Abrv = "DemoAbrv" });
           

            return LstVehicleMake;
        }

      
    }
}
