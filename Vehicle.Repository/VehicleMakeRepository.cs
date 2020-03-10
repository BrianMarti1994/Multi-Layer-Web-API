
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common.Common;
using Vehicle.DAL;
using Vehicle.Model.Common;

using AutoMapper;
using Vehicle.Repository.Common;
using Vehicle.Common;

namespace Vehicle.Repository
{
    public class VehicleMakeRepository : Repository<Model.VehicleMake>, IVehicleMakeRepository
    {
        Generic generic = new Generic();
        public VehicleMakeRepository(VehicleDbEntities context) : base(context)
        {
        }

        public async Task<List<IVehicleMake>> GetAllVehiclesMake(PaginatedInputModel pagingParams)
        {

            List<IVehicleMake> listVehicleMake = new List<IVehicleMake>();
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
                       
                        var objd = unitOfWork.VehicleMakes.GetAll().Where(s => s.Name.Contains(filterValue) || s.Abrv.Contains(filterValue))
                            .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                             .Take(pagingParams.PageSize)
                             .ToList();
                        listVehicleMake = Mapper.Map<List<IVehicleMake>>(objd);

                        return await Task.FromResult(listVehicleMake);
                    }
                    foreach (var sortingParam in pagingParams.SortingParams.Where(x => !String.IsNullOrEmpty(x.ColumnName)))
                    {
                        stortingCol = sortingParam.ColumnName;
                    }
                    
                    switch (stortingCol)
                    {

                        case "Id":
                            var objId = unitOfWork.VehicleMakes.GetAll().OrderByDescending(x => x.Id).Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                             .Take(pagingParams.PageSize)
                             .ToList();
                            listVehicleMake = Mapper.Map<List<IVehicleMake>>(objId);
                            break;

                        case "Name":
                            var objName = unitOfWork.VehicleMakes.GetAll().OrderByDescending(x => x.Name)
                                .OrderByDescending(x => x.Name)
                              .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                             .Take(pagingParams.PageSize)
                             .ToList();
                            listVehicleMake = Mapper.Map<List<IVehicleMake>>(objName);
                            break;

                        case "Abrv":
                            var objAbrv = unitOfWork.VehicleMakes.GetAll().OrderByDescending(x => x.Abrv)
                                .OrderByDescending(x => x.Abrv)
                               .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                             .Take(pagingParams.PageSize)
                             .ToList();
                            listVehicleMake = Mapper.Map<List<IVehicleMake>>(objAbrv);
                            break;

                        default:
                            var objDefault = unitOfWork.VehicleMakes.GetAll().OrderBy(c => c.Name)
                                .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                             .Take(pagingParams.PageSize)
                             .ToList();
                            listVehicleMake = Mapper.Map<List<IVehicleMake>>(objDefault);
                            break;

                    }
                    return await Task.FromResult(listVehicleMake);


                }
            }
            catch (Exception ex)
            {
                //Logs can be stored into Database or can be Email to developer.

                generic.ErrorLogging(ex, "GetAllVehiclesMake");

                return listVehicleMake;
            }
        }


        public async Task<bool> SaveVehiclesMake(Model.VehicleMake vehicleMake)
        {
            try
            {
           
            using (var unitOfWork = new UnitOfWork(new VehicleDbEntities()))
            {

                unitOfWork.VehicleMakes.Add(new Model.VehicleMake() { Id = generic.UniqueId(), Name = vehicleMake.Name, Abrv = vehicleMake.Abrv });
              

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

                generic.ErrorLogging(ex, "SaveVehiclesMake");

                return false;
            }
        }

        public async Task<bool> UpdateVehicleMake(Model.VehicleMake vehicleMake)
        {
            try
            {

                using (var unitOfWork = new UnitOfWork(new VehicleDbEntities()))
                {
                    var Obj = unitOfWork.VehicleMakes.SingleOrDefault(s => s.Id.Equals(vehicleMake.Id));
                    Obj.Name = vehicleMake.Name;
                    Obj.Abrv = vehicleMake.Abrv;

                    if (unitOfWork.Save() == 1)
                        return await Task.FromResult(true);
                    return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                //Logs can be stored into Database or can be Email to developer.

                generic.ErrorLogging(ex, "UpdateVehicleMake");

                return false;
            }
        }

        public async Task<bool> DeleteVehicleMake(Model.VehicleMake vehicleMake)
        {
            try
            {
                
            using (var unitOfWork = new UnitOfWork(new VehicleDbEntities()))
            {
                var VehicleMakes = unitOfWork.VehicleMakes.SingleOrDefault(s => s.Id.Equals(vehicleMake.Id));
                unitOfWork.VehicleMakes.Remove(VehicleMakes);
                if (unitOfWork.Save() == 1)
                    return await Task.FromResult(true);
                return await Task.FromResult(false);
            }
            }
            catch (Exception ex)
            {
                //Logs can be stored into Database or can be Email to developer.

                generic.ErrorLogging(ex, "DeleteVehicleMake");

                return false;
            }
        }

      
     

    }
}
