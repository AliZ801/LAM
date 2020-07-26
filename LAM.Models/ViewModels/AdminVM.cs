using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAM.Models.ViewModels
{
    public class AdminVM
    {
        public Leave Leave { get; set; }

        public LType LType { get; set; }

        public IEnumerable<SelectListItem> LTypeList { get; set; }
    }
}
