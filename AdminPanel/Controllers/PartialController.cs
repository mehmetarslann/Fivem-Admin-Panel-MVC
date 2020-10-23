using AdminPanel.Kontrol;
using AdminPanel.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        private sunucu1sEntities db = new sunucu1sEntities();
        [AdminAuthorize]
        public PartialViewResult UserPartial()
        {
            return PartialView(db.users.ToList().Take(5));
        }
        [AdminAuthorize]
        public PartialViewResult VehiclePartial()
        {
            return PartialView(db.vehicles.ToList().Take(5));
        }
        [AdminAuthorize]
        public PartialViewResult illegalPartial()
        {
            return PartialView(db.illegalsatis.ToList().Take(5));
        }
        [AdminAuthorize]
        public PartialViewResult LauncherUyePartial()
        {
            return PartialView(db.launcher_uyeler.ToList().Take(5));
        }
    }
}