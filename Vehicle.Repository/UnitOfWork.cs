using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL;
using Vehicle.Repository;
using Vehicle.Repository.Common;


namespace Vehicle.Common.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehicleDbEntities _context;

        public UnitOfWork(VehicleDbEntities context)
        {
            _context = context;
            VehicleMakes = new VehicleMakeRepository(_context);
            VehicleModels = new VehicleModelRepository(_context);
        }

        public IVehicleMakeRepository VehicleMakes { get; private set; }
        public IVehicleModelRepository VehicleModels { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
