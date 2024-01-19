using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    public class Account : Controller
    {
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}
