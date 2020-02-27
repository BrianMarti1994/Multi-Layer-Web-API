
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
                   
                    var objd = unitOfWork.VehicleMakes.GetAll().ToList();
                if (objd != null)
                {
                    list = Mapper.Map<List<IVehicleMake>>(objd);

                    if (pagingParams != null && pagingParams.FilterParam.Any())
                    {
                        list = Filter<IVehicleMake>.FilteredData(pagingParams.FilterParam, list).ToList();
                    }
                    if (pagingParams != null && pagingParams.SortingParams.Count() > 0 )
                    {
                        list = Sorting<IVehicleMake>.SortData(list, pagingParams.SortingParams).ToList();
                    }
                    return await Paging<IVehicleMake>.CreateAsync(list, pagingParams.PageNumber, pagingParams.PageSize);
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

                objGen.ErrorLogging(ex, "GetAllVehiclesMake");

                return list ;
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
                var VehicleMakes = unitOfWork.VehicleMakes.SingleOrDefault(s => s.Id.Equals(ObjVechicle.Id));
                VehicleMakes.Name = ObjVechicle.Name;
                VehicleMakes.Abrv = ObjVechicle.Abrv;

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
