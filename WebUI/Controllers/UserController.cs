using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Utilities.ControllerFilters;

namespace WebUI.Controllers
{
    [TypeFilter(typeof(ControllerFilter))]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IUserDetayService _userDetayService;
        private IilService _ilService;
        private IilceService _ilceService;
        private IKurumTuruService _kurumTuruService;
        private IKurumTipiService _kurumTipiService;
        private IBransService _bransService;

        public UserController(IUserService userService, IUserDetayService userDetayService,
            IilService ilService, IilceService ilceService, IKurumTuruService kurumTuruService,
            IKurumTipiService kurumTipiService, IBransService bransService)
        {
            _userService = userService;
            _userDetayService = userDetayService;
            _ilService = ilService;
            _ilceService = ilceService;
            _kurumTuruService = kurumTuruService;
            _kurumTipiService = kurumTipiService;
            _bransService = bransService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CikisYap()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Profil()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            User user = _userService.GetById(userId).Data;
            return View(user);
        }

        public IActionResult OkulBilgileri()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            UserDetay userDetay = new UserDetay();
            userDetay = _userDetayService.GetByUserId(userId).Data;
            List<SelectListItem> ilListe = null;
            List<SelectListItem> ilceListe = null;
            List<SelectListItem> kurumTuruListe = null;
            List<SelectListItem> kurumTipiListe = null;
            List<SelectListItem> bransListe = null;

            if (userDetay != null)
            {
                ilListe = (from i in _ilService.GetAll().Data
                           select new SelectListItem
                           {
                               Text = i.Adi,
                               Value = i.Id.ToString()
                           }).ToList();
                ilceListe = (from i in _ilceService.GetByListilId(userDetay.ilId).Data
                             select new SelectListItem
                             {
                                 Text = i.Adi,
                                 Value = i.Id.ToString()
                             }).ToList();
                kurumTuruListe = (from i in _kurumTuruService.GetAllAktif().Data
                                  select new SelectListItem
                                  {
                                      Text = i.Adi,
                                      Value = i.Id.ToString()
                                  }).ToList();
                kurumTipiListe = (from i in _kurumTipiService.GetByKurumTurIdList(userDetay.KurumTurId).Data
                                  orderby i.Adi
                                  select new SelectListItem
                                  {
                                      Text = i.Adi,
                                      Value = i.Id.ToString()
                                  }).ToList();
                bransListe = (from i in _bransService.GetByKurumTurIdAll(userDetay.KurumTurId).Data
                              orderby i.Adi
                              select new SelectListItem
                              {
                                  Text = i.Adi,
                                  Value = i.Id.ToString()
                              }).ToList();
            }
            else
            {
                ilListe = (from i in _ilService.GetAll().Data
                           select new SelectListItem
                           {
                               Text = i.Adi,
                               Value = i.Id.ToString()
                           }).ToList();
                kurumTuruListe = (from i in _kurumTuruService.GetAllAktif().Data
                                  select new SelectListItem
                                  {
                                      Text = i.Adi,
                                      Value = i.Id.ToString()
                                  }).ToList();

            }
            ViewData["ilListe"] = ilListe;
            ViewData["ilceListe"] = ilceListe;
            ViewData["KurumTuruListe"] = kurumTuruListe;
            ViewData["KurumTipiListe"] = kurumTipiListe;
            ViewData["BransListe"] = bransListe;
            return View(userDetay);
        }

        public List<SelectListItem> ileGoreilceListele(int id)
        {
            return (from i in _ilceService.GetByListilId(id).Data
                    select new SelectListItem
                    {
                        Text = i.Adi,
                        Value = i.Id.ToString()
                    }).ToList();
        }

        public List<SelectListItem> KurumTuruneGoreTipListele(int id)
        {
            return (from i in _kurumTipiService.GetByKurumTurIdList(id).Data
                    orderby i.Adi
                    select new SelectListItem
                    {
                        Text = i.Adi,
                        Value = i.Id.ToString()
                    }).ToList();
        }

        public List<SelectListItem> KurumTuruneGoreBransListele(int id)
        {
            return (from i in _bransService.GetByKurumTurIdAll(id).Data
                    orderby i.Adi
                    select new SelectListItem
                    {
                        Text = i.Adi,
                        Value = i.Id.ToString()
                    }).ToList();
        }
    }
}
