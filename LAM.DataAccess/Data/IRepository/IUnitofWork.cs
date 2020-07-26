using System;
using System.Collections.Generic;
using System.Text;

namespace LAM.DataAccess.Data.IRepository
{
    public interface IUnitofWork : IDisposable
    {
        ILeaveRepo Leave { get; }

        ILTypeRepo LType { get; }

        void Save();
    }
}
