using MiniProject.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject.Web.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public JsonResult cariId(int idRole)
        {
            var data = new
            {
                success = true,
                item = MMenuRepo.getId(idRole)
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckNama(string nama)
        {
            var res = new
            {
                success = true,
                data = MUserRepo.CheckNama(nama),
                alertType = "error",
                alertStrong = "ERROR !",
                alertMessage = "Your Data With Name </strong>(" + nama + ")</strong> is Already Exists"
            };
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}