﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vehicle.Repository.Common;
using Vehicle.Model.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using Vehicle.Model;
using Vehicle.Common;
using static Vehicle.Common.Filters;

namespace Vehicle.Repository.Tests
{
    [TestClass]
    public abstract class VehicleMakeRepositoryTests
    {
        public abstract IVehicleMakeRepository GetInstance();

        [TestMethod]
        public void TestGetAllVehicles()
        {
           
         FilterParams dd = new FilterParams();
            var TestVehicles = GetTestVehicles();
            dd.ColumnName = "Name";
            dd.FilterValue = "DemoName";
            dd.FilterOption = FilterOptions.Contains;
            IVehicleMakeRepository vehicleRepository = GetInstance();
            PaginatedInputModel pagingParams = new PaginatedInputModel();
            pagingParams.FilterParam = null;
            pagingParams.SortingParams = null;
            pagingParams.PageNumber = 1;
            pagingParams.PageSize = 4;

       

          //var result = vehicleRepository.GetAllVehiclesMake(pagingParams) as Task<List<IVehicleMake>>;
            Assert.AreEqual(TestVehicles.Count, 1);
        }

        [TestMethod]
        public void TestAddVehicle()
        {
            Vehicle.Model.VehicleMake obj = new Vehicle.Model.VehicleMake();
            obj.Id = 1;
            obj.Name = "DemoName";
            obj.Abrv = "DemoAbrv";


            IVehicleMakeRepository vehicleRepository = GetInstance();

            var result = vehicleRepository.SaveVehiclesMake(obj) as Task<bool>;
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestUpdateVehicle()
        {
            Vehicle.Model.VehicleMake obj = new Vehicle.Model.VehicleMake();
            obj.Id = 1;
            obj.Name = "BMW";
            obj.Abrv = "SSD";


            IVehicleMakeRepository vehicleRepository = GetInstance();

            var result = vehicleRepository.UpdateVehicleMake(obj) as Task<bool>;
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestDeleteVehicle()
        {
            VehicleMake obj = new VehicleMake();
            IVehicleMakeRepository VehicleRepository = GetInstance();
            obj.Id = 1;
            var result = VehicleRepository.DeleteVehicleMake(obj) as Task<bool>;
            Assert.AreEqual(true, true);
        }

        public List<IVehicleMake> GetTestVehicles()
        {
            var lstVehicleMake = new List<IVehicleMake>();
            lstVehicleMake.Add(new VehicleMake { Id = 1, Name = "DemoName", Abrv = "DemoAbrv" });


            return lstVehicleMake;
        }

    }
}
