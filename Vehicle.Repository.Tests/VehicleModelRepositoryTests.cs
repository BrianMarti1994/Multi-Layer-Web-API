using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vehicle.Repository.Common;
using Vehicle.Model.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using Vehicle.Model;
using Vehicle.Common;

namespace Vehicle.Repository.Tests
{
    [TestClass]
    public abstract class VehicleModelRepositoryTests
    {

        public abstract IVehicleModelRepository GetInstance();

        [TestMethod]
        public void TestGetAllVehicles()
        {

            IVehicleModelRepository VehicleRepository = GetInstance();
            PaginatedInputModel pagingParams = new PaginatedInputModel();
            pagingParams.FilterParam = null;
            pagingParams.SortingParams = null;
            pagingParams.PageNumber = 1;
            pagingParams.PageSize = 4;
            var TestVehicles = GetTestVehicles();
          //  var result = VehicleRepository.GetAllVehiclesModel(pagingParams) as Task<List<IVehicleModel>>;
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


            IVehicleModelRepository VehicleRepository = GetInstance();


            var result = VehicleRepository.SaveVehiclesModel(obj) as Task<bool>;
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestUpdateVehicle()
        {
            Vehicle.Model.VehicleModel obj = new Vehicle.Model.VehicleModel();
            obj.MakeId = 3;
            obj.Name = "BMW";
            obj.Abrv = "SSD";


            IVehicleModelRepository VehicleRepository = GetInstance();


            var result = VehicleRepository.UpdateVehicleModel(obj) as Task<bool>;
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestDeleteVehicle()
        {

            IVehicleModelRepository VehicleRepository = GetInstance();
            VehicleModel obj = new VehicleModel();
            obj.Id = 1;

            var result = VehicleRepository.DeleteVehicleModel(obj) as Task<bool>;
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
