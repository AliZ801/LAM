using LAM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAM.DataAccess.Data.IRepository
{
    public interface ILeaveRepo : IRepository<Leave>
    {
        void Update(Leave leave);
    }
}
