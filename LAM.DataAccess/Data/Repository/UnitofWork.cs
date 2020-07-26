using LAM.DataAccess.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAM.DataAccess.Data.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _db;

        public UnitofWork(ApplicationDbContext db)
        {
            _db = db;
            Leave = new LeaveRepo(_db);
            LType = new LTypeRepo(_db);
        }

        public ILeaveRepo Leave { get; private set; }

        public ILTypeRepo LType { get; private set; }

        public void Dispose()
        {
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
