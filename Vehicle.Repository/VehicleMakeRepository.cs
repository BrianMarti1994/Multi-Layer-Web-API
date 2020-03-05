
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
        Generic objGen = new Generic();
        public VehicleMakeRepository(VehicleDbEntities context) : base(context)
        {
        }

        public async Task<List<IVehicleMake>> GetAllVehiclesMake(PaginatedInputModel pagingParams)
        {

            List<IVehicleMake> list = new List<IVehicleMake>();
            try
            {
                using (var unitOfWork = new UnitOfWork(new VehicleDbEntities()))
                {
                    string FilterValue = string.Empty, StortingCol = string.Empty;
                    IEnumerable<string> disFilterValue = pagingParams.FilterParam.Where(x => !String.IsNullOrEmpty(x.FilterValue)).Select(x => x.FilterValue).Distinct();
                    foreach (string FilterVal in disFilterValue)
                    {
                        FilterValue = FilterVal;
                    }
                    if (!string.IsNullOrEmpty(FilterValue))
                    {
                       
                        var objd = unitOfWork.VehicleMakes.GetAll().Where(s => s.Name.Contains(FilterValue) || s.Abrv.Contains(FilterValue))
                            .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                             .Take(pagingParams.PageSize)
                             .ToList();
                        list = Mapper.Map<List<IVehicleMake>>(objd);

                        return await Task.FromResult(list);
                    }
                    foreach (var sortingParam in pagingParams.SortingParams.Where(x => !String.IsNullOrEmpty(x.ColumnName)))
                    {
                        StortingCol = sortingParam.ColumnName;
                    }
                    
                    switch (StortingCol)
                    {

                        case "Id":
                            var obId = unitOfWork.VehicleMakes.GetAll().OrderByDescending(x => x.Id).Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                             .Take(pagingParams.PageSize)
                             .ToList();
                            list = Mapper.Map<List<IVehicleMake>>(obId);
                            break;

                        case "Name":
                            var obNam = unitOfWork.VehicleMakes.GetAll().OrderByDescending(x => x.Name)
                                .OrderByDescending(x => x.Name)
                              .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                             .Take(pagingParams.PageSize)
                             .ToList();
                            list = Mapper.Map<List<IVehicleMake>>(obNam);
                            break;

                        case "Abrv":
                            var obAb = unitOfWork.VehicleMakes.GetAll().OrderByDescending(x => x.Abrv)
                                .OrderByDescending(x => x.Abrv)
                               .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                             .Take(pagingParams.PageSize)
                             .ToList();
                            list = Mapper.Map<List<IVehicleMake>>(obAb);
                            break;

                        default:
                            var objd = unitOfWork.VehicleMakes.GetAll().OrderBy(c => c.Name)
                                .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                             .Take(pagingParams.PageSize)
                             .ToList();
                            list = Mapper.Map<List<IVehicleMake>>(objd);
                            break;

                    }
                    return await Task.FromResult(list);


                }
            }
            catch (Exception ex)
            {
                //Logs can be stored into Database or can be Email to developer.

                objGen.ErrorLogging(ex, "GetAllVehiclesMake");

                return list;
            }
        }


        public async Task<bool> SaveVehiclesMake(Model.VehicleMake ObjVechicle)
        {
            try
            {
           
            using (var unitOfWork = new UnitOfWork(new VehicleDbEntities()))
            {

                unitOfWork.VehicleMakes.Add(new Model.VehicleMake() { Id = objGen.UniqueId(), Name = ObjVechicle.Name, Abrv = ObjVechicle.Abrv });
              

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

                objGen.ErrorLogging(ex, "SaveVehiclesMake");

                return false;
            }
        }

        public async Task<bool> UpdateVehicleMake(Model.VehicleMake ObjVechicle)
        {
            try
            {

                using (var unitOfWork = new UnitOfWork(new VehicleDbEntities()))
                {
                    var Obj = unitOfWork.VehicleMakes.SingleOrDefault(s => s.Id.Equals(ObjVechicle.Id));
                    Obj.Name = ObjVechicle.Name;
                    Obj.Abrv = ObjVechicle.Abrv;

                    if (unitOfWork.Save() == 1)
                        return await Task.FromResult(true);
                    return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                //Logs can be stored into Database or can be Email to developer.

                objGen.ErrorLogging(ex, "UpdateVehicleMake");

                return false;
            }
        }

        public async Task<bool> DeleteVehicleMake(Model.VehicleMake ObjVechicle)
        {
            try
            {
                
            using (var unitOfWork = new UnitOfWork(new VehicleDbEntities()))
            {
                var VehicleMakes = unitOfWork.VehicleMakes.SingleOrDefault(s => s.Id.Equals(ObjVechicle.Id));
                unitOfWork.VehicleMakes.Remove(VehicleMakes);
                if (unitOfWork.Save() == 1)
                    return await Task.FromResult(true);
                return await Task.FromResult(false);
            }
            }
            catch (Exception ex)
            {
                //Logs can be stored into Database or can be Email to developer.

                objGen.ErrorLogging(ex, "DeleteVehicleMake");

                return false;
            }
        }

      
     

    }
}
