using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAM.DataAccess.Data.IRepository;
using LAM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LAM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LType : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public AdminVM AVM { get; set; }

        public LType(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddType(int? id)
        {
            AVM = new AdminVM() { LType = new Models.LType() };

            if(id != null)
            {
                AVM.LType = _unitofWork.LType.Get(id.GetValueOrDefault());
            }

            return View(AVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddType()
        {
            if (ModelState.IsValid)
            {
                if(AVM.LType.Id == 0)
                {
                    _unitofWork.LType.Add(AVM.LType);
                }
                else
                {
                    _unitofWork.LType.Update(AVM.LType);
                }

                _unitofWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(AVM);
            }
        }

        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.LType.GetAll() });
        }

        #endregion
    }
}
