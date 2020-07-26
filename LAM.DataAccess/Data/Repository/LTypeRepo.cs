using LAM.DataAccess.Data.IRepository;
using LAM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAM.DataAccess.Data.Repository
{
    public class LTypeRepo : Repository<LType>, ILTypeRepo
    {
        private readonly ApplicationDbContext _db;

        public LTypeRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetDropDownListForLType()
        {
            return _db.LType.Select(i => new SelectListItem()
            {
                Text = i.Type,
                Value = i.Id.ToString()
            });
        }

        public void Update(LType lType)
        {
            var tFromDb = _db.LType.FirstOrDefault(i => i.Id == lType.Id);

            tFromDb.Type = lType.Type;

            _db.SaveChanges();
        }
    }
}
