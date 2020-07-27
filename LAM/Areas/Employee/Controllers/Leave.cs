using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAM.DataAccess.Data.IRepository;
using LAM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using LAM.Utility;

namespace LAM.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class Leave : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public AdminVM AVM { get; set; }

        public Leave(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddLeave(int? id)
        {
            AVM = new AdminVM()
            {
                Leave = new Models.Leave(),
                LTypeList = _unitofWork.LType.GetDropDownListForLType()
            };

            if(id != null)
            {
                AVM.Leave = _unitofWork.Leave.Get(id.GetValueOrDefault());
            }
            else
            {
                AVM.Leave.AL = 30;
            }

            return View(AVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddLeave()
        {
            if (ModelState.IsValid)
            {
                if(AVM.Leave.Id == 0)
                {
                    AVM.Leave.Status = SD.Submitted;
                    AVM.Leave.AL = SD.AL;

                    _unitofWork.Leave.Add(AVM.Leave);
                }
                else
                {
                    AVM.Leave.Status = SD.Submitted;

                    _unitofWork.Leave.Update(AVM.Leave);
                }

                _unitofWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                AVM.LTypeList = _unitofWork.LType.GetDropDownListForLType();

                return View(AVM);
            }
        }

        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.Leave.GetAll() });
        }

        #endregion
    }
}
