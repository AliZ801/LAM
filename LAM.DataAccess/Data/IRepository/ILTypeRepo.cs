using LAM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAM.DataAccess.Data.IRepository
{
    public interface ILTypeRepo : IRepository<LType>
    {
        IEnumerable<SelectListItem> GetDropDownListForLType();

        void Update(LType lType);
    }
}
