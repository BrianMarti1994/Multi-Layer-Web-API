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
        Generic generic = new Generic();

        public VehicleModelRepository(VehicleDbEntities context) : base(context)
        {
        }


        public async Task<List<Model.VehicleModel>> GetAllVehiclesModel(PaginatedInputModel pagingParams)
        {
            List<Model.VehicleModel> listVehicleModel = new List<Model.VehicleModel>();

            try
            {

                using (var unitOfWork = new UnitOfWork(new VehicleDbEntities()))
                {
                    string filterValue = string.Empty, stortingCol = string.Empty;
                    IEnumerable<string> disFilterValue = pagingParams.FilterParam.Where(x => !String.IsNullOrEmpty(x.FilterValue)).Select(x => x.FilterValue).Distinct();
                    foreach (string filterVal in disFilterValue)
                    {
                        filterValue = filterVal;
                    }
                    if (!string.IsNullOrEmpty(filterValue))
                    {

                        var objd = unitOfWork.VehicleModels.GetAll().Where(s => s.Name.Contains(filterValue) || s.Abrv.Contains(filterValue))
                            .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                             .Take(pagingParams.PageSize)
                             .ToList();
                        listVehicleModel = Mapper.Map<List<Model.VehicleModel>>(objd);

                        return await Task.FromResult(listVehicleModel);
                    }
                    foreach (var sortingParam in pagingParams.SortingParams.Where(x => !String.IsNullOrEmpty(x.ColumnName)))
                    {
                        stortingCol = sortingParam.ColumnName;
                    }


                    switch (stortingCol)
                    {

                        case "Id":
                            var obId = unitOfWork.VehicleModels.GetAll().OrderByDescending(x => x.Id).Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                             .Take(pagingParams.PageSize)
                             .ToList();
                            listVehicleModel = Mapper.Map<List<Model.VehicleModel>>(obId);
                            break;
                        //case "MakeId":
                        //    var obMakeId = unitOfWork.VehicleModels.GetAll()
                        //        .OrderByDescending(x => x.).Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                        //     .Take(pagingParams.PageSize)
                        //     .ToList();
                        //    listVehicleModel = Mapper.Map<List<IVehicleModel>>(obMakeId);
                        //    break;
                        case "Name":
                            var obNam = unitOfWork.VehicleModels.GetAll().OrderByDescending(x => x.Name)
                                .OrderByDescending(x => x.Name)
                              .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                             .Take(pagingParams.PageSize)
                             .ToList();
                            listVehicleModel = Mapper.Map<List<Model.VehicleModel>>(obNam);
                            break;

                        case "Abrv":
                            var obAb = unitOfWork.VehicleModels.GetAll().OrderByDescending(x => x.Abrv)
                                .OrderByDescending(x => x.Abrv)
                               .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                             .Take(pagingParams.PageSize)
                             .ToList();
                            listVehicleModel = Mapper.Map<List<Model.VehicleModel>>(obAb);
                            break;

                        default:
                            var objd = unitOfWork.VehicleModels.GetAll().OrderBy(c => c.Name)
                                .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                             .Take(pagingParams.PageSize)
                             .ToList();
                            listVehicleModel = Mapper.Map<List<Model.VehicleModel>>(objd);
                            break;

                    }
                    return await Task.FromResult(listVehicleModel);

                }
            }
            catch (Exception ex)
            {
                //Logs can be stored into Database or can be Email to developer.

                generic.ErrorLogging(ex, "GetAllVehiclesModel");

                return listVehicleModel;
            }
        }

        public async Task<bool> SaveVehiclesModel(Model.VehicleModel vehicleModel)
        {
            try
            {

           
            using (var unitOfWork = new UnitOfWork(new VehicleDbEntities()))
            {
                unitOfWork.VehicleModels.Add(new Model.VehicleModel() { Id = generic.UniqueId(), MakeId = vehicleModel.MakeId, Name = vehicleModel.Name, Abrv = vehicleModel.Abrv });


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

                generic.ErrorLogging(ex, "SaveVehiclesModel");

                return false;
            }
        }

        public async Task<bool> UpdateVehicleModel(Model.VehicleModel vehicleModel)
        {
            try
            {


                using (var unitOfWork = new UnitOfWork(new VehicleDbEntities()))
                {
                    var Obj = unitOfWork.VehicleModels.SingleOrDefault(s => s.Id.Equals(vehicleModel.Id));
                    Obj.Name = vehicleModel.Name;
                    Obj.Abrv = vehicleModel.Abrv;

                    if (unitOfWork.Save() == 1)
                        return await Task.FromResult(true);
                    return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                //Logs can be stored into Database or can be Email to developer.

                generic.ErrorLogging(ex, "UpdateVehicleModel");

                return false;
            }
        }

        public async Task<bool> DeleteVehicleModel(Model.VehicleModel vehicleModel)
        {
            try
            {

           
            using (var unitOfWork = new UnitOfWork(new VehicleDbEntities()))
            {
                   
                    var VehicleModels = unitOfWork.VehicleModels.Include(X => X.VehicleMake).Single(X => X.Id == vehicleModel.Id);

                   

                    unitOfWork.VehicleModels.Remove(VehicleModels);
                if (unitOfWork.Save() == 1)
                    return await Task.FromResult(true);
                return await Task.FromResult(false);
            }
            }
            catch (Exception ex)
            {
                //Logs can be stored into Database or can be Email to developer.

                generic.ErrorLogging(ex, "DeleteVehicleModel");

                return false;
            }
        }

       

    }
    }

