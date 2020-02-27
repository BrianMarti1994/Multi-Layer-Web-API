using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL;
using Vehicle.Common.Common;

using Vehicle.Model.Common;
using Vehicle.Repository.Common;
using AutoMapper;
using Vehicle.Common;

namespace Vehicle.Repository
{
   public class VehicleModelRepository : Repository<Model.VehicleModel>, IVehicleModelRepository
    {
        Generic objGen = new Generic();

        public VehicleModelRepository(VehicleDbEntities context) : base(context)
        {
        }


        public async Task<List<IVehicleModel>> GetAllVehiclesModel(PaginatedInputModel pagingParams)
        {
            List<IVehicleModel> list = new List<IVehicleModel>();

            try
            {

                using (var unitOfWork = new UnitOfWork(new VehicleDbEntities()))
                {

                    var objd = unitOfWork.VehicleModels.GetAll().ToList();
                    if (objd != null)
                    {
                        list = Mapper.Map<List<IVehicleModel>>(objd);

                        if (pagingParams != null && pagingParams.FilterParam.Any())
                        {
                            list = Filter<IVehicleModel>.FilteredData(pagingParams.FilterParam, list).ToList();
                        }
                        if (pagingParams != null && pagingParams.SortingParams.Count() > 0 )
                        {
                            list = Sorting<IVehicleModel>.SortData(list, pagingParams.SortingParams).ToList();

                        }
                        return await Paging<IVehicleModel>.CreateAsync(list, pagingParams.PageNumber, pagingParams.PageSize);
                    }
                    else
                    {
                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                //Logs can be stored into Database or can be Email to developer.

                objGen.ErrorLogging(ex, "GetAllVehiclesModel");

                return list;
            }
        }

        public async Task<bool> SaveVehiclesModel(Model.VehicleModel ObjVechicle)
        {
            try
            {

           
            using (var unitOfWork = new UnitOfWork(new VehicleDbEntities()))
            {
                unitOfWork.VehicleModels.Add(new Model.VehicleModel() { Id = objGen.UniqueId(), MakeId = ObjVechicle.MakeId, Name = ObjVechicle.Name, Abrv = ObjVechicle.Abrv });


                if (unitOfWork.Save() == 1)
                {
                    return await Task.FromResult(true);
                }
                else
                {
                    return await Task.FromResult(false);

                }
                }
            }
            catch (Exception ex)
            {
                //Logs can be stored into Database or can be Email to developer.

                objGen.ErrorLogging(ex, "SaveVehiclesModel");

                return false;
            }
        }

        public async Task<bool> UpdateVehicleModel(Model.VehicleModel ObjVechicle)
        {
            try
            {

           
            using (var unitOfWork = new UnitOfWork(new VehicleDbEntities()))
            {
                var VehicleModels = unitOfWork.VehicleModels.SingleOrDefault(s => s.Id.Equals(ObjVechicle.Id));
                VehicleModels.Name = ObjVechicle.Name;
                VehicleModels.Abrv = ObjVechicle.Abrv;
                
                if (unitOfWork.Save() == 1)
                    return await Task.FromResult(true);
                return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                //Logs can be stored into Database or can be Email to developer.

                objGen.ErrorLogging(ex, "UpdateVehicleModel");

                return false;
            }
        }

        public async Task<bool> DeleteVehicleModel(Model.VehicleModel ObjVechicle)
        {
            try
            {

           
            using (var unitOfWork = new UnitOfWork(new VehicleDbEntities()))
            {
                var VehicleModels = unitOfWork.VehicleModels.SingleOrDefault(s => s.Id.Equals(ObjVechicle.Id));
                unitOfWork.VehicleModels.Remove(VehicleModels);
                if (unitOfWork.Save() == 1)
                    return await Task.FromResult(true);
                return await Task.FromResult(false);
            }
            }
            catch (Exception ex)
            { 
                //Logs can be stored into Database or can be Email to developer.

                objGen.ErrorLogging(ex, "DeleteVehicleModel");

                return false;
            }
        }

       

    }
    }

