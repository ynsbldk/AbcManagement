using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbcManagement.Website.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        #region Redirect
        [AllowAnonymous]
        public virtual ActionResult Error()
        {
            return Redirect("/Error.html");
        }   

        public virtual ActionResult HomePage()
        {
            return RedirectToAction("Index", "Home");
        }
        #endregion

        [NonAction]
        private void ShowMessage(string title, string body, string type)
        {
            TempData["modalTitle"] = title;
            TempData["modalBody"] = body;
            TempData["messageType"] = type;
            TempData.Keep();
        }

         
    }
}
