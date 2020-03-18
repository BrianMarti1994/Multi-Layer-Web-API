using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service.Tests
{
    [TestClass]
   public  abstract class VehicleModelServiceTests
    {
        public abstract IVehicleModelService GetInstance();

        [TestMethod]
        public void TestGetAllVehicles()
        {

            IVehicleModelService vehicleService = GetInstance();
            PaginatedInputModel pagingParams = new PaginatedInputModel();
            pagingParams.FilterParam = null;
            pagingParams.SortingParams = null;
            pagingParams.PageNumber = 1;
            pagingParams.PageSize = 4;
            var TestVehicles = GetTestVehicles();
            
           // var result = vehicleService.GetAllVehiclesModel(pagingParams) as Task<List<IVehicleModel>>;
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


            IVehicleModelService vehicleService = GetInstance();

            var result = vehicleService.SaveVehiclesModel(obj) as Task<bool>;
            Assert.AreEqual(true, true);
        }


        [TestMethod]
        public void TestUpdateVehicle()
        {
            Vehicle.Model.VehicleModel obj = new Vehicle.Model.VehicleModel();
            obj.MakeId = 3;
            obj.Name = "BMW";
            obj.Abrv = "SSD";


            IVehicleModelService vehicleService = GetInstance();

            var result = vehicleService.UpdateVehicleModel(obj) as Task<bool>;
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestDeleteVehicle()
        {

            IVehicleModelService vehicleService = GetInstance();
            IVehicleModel obj = new VehicleModel();
            obj.Id = 1;
            var result = vehicleService.DeleteVehicleModel(obj) as Task<bool>;
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
