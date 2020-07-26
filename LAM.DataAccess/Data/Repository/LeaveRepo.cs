using LAM.DataAccess.Data.IRepository;
using LAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAM.DataAccess.Data.Repository
{
    public class LeaveRepo : Repository<Leave>, ILeaveRepo
    {
        private readonly ApplicationDbContext _db;

        public LeaveRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Leave leave)
        {
            var lFromDb = _db.Leave.FirstOrDefault(i => i.Id == leave.Id);

            lFromDb.AL = leave.AL;
            lFromDb.Reason = leave.Reason;
            lFromDb.SDate = leave.SDate;
            lFromDb.EDate = leave.EDate;
            lFromDb.Address = leave.Address;
            lFromDb.LType = leave.LType;
            lFromDb.Status = leave.Status;

            _db.SaveChanges();
        }
    }
}
