using AdminPanel.Kontrol;
using AdminPanel.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
    public class AdminController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();
        // GET: Admin
        public ActionResult Giris()
        {
            return View();
        }
        [AdminAuthorize]
        public ActionResult Index()
        {
            var userlist = db.users.ToList();
            List<int> kullanici = new List<int>();
            var user = userlist.Select(x => x.identifier).Distinct();

            foreach (var item in user)
            {
                kullanici.Add(userlist.Count(x => x.identifier == item));
            }

            var launcheruyelist = db.launcher_uyeler.ToList();
            List<int> launcheruye = new List<int>();
            var launcherlistesi = launcheruyelist.Select(x => x.uye_id).Distinct();

            foreach (var launcher in launcherlistesi)
            {
                launcheruye.Add(launcheruyelist.Count(x => x.uye_id == launcher));
            }

            var whitelistgetir = db.whitelist.ToList();
            List<int> whitelistt = new List<int>();
            var twhitelist = whitelistgetir.Select(x => x.identifier).Distinct();

            foreach (var white in twhitelist)
            {
                whitelistt.Add(whitelistgetir.Count(x => x.identifier == white));
            }

            var aracgetir = db.vehicles.ToList();
            List<int> araclist = new List<int>();
            var tarac = aracgetir.Select(x => x.id).Distinct();

            foreach (var arac in tarac)
            {
                araclist.Add(aracgetir.Count(x => x.id == arac));
            }

            var UserCount = kullanici;
            ViewBag.KullaniciSayi = UserCount.Count();
            ViewBag.LauncherToplam = launcheruye.Count();
            ViewBag.Whitelist = whitelistt.Count();
            ViewBag.AracSayisi = araclist.Count();
            return PartialView();
        }

        [HttpPost]
        public ActionResult Giris(accounts u)
        {
            var kadi = db.accounts.FirstOrDefault(x => x.username == u.username && x.password == u.password);
            if (kadi != null)
            {
                Session["Kadi"] = kadi;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Hata = "Lütfen kullanıcı adı ve şifrenizi kontrol edip yeniden deneyiniz.";
            }
            return View();

        }
        public ActionResult Cikis()
        {
            Session.Clear();
            return RedirectToAction("Giris", "Admin");
        }

    }
}