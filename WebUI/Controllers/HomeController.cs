using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IKurumTuruService _kurumTuruService;
        private IUserService _userService;
        private IAuthService _autoService;

        public HomeController(IKurumTuruService kurumTuruService, IUserService userService, IAuthService autoService)
        {
            _kurumTuruService = kurumTuruService;
            _userService = userService;
            _autoService = autoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KayitOl()
        {
            UserViewModel userVM = new UserViewModel();
            return View(userVM);
        }

        [HttpPost]
        public IActionResult KayitOl(UserViewModel model)
        {
            IDataResult<User> result = null;
            if (model.SozlesmeOnay == true)
            {
                UserForRegisterDto user = new UserForRegisterDto();
                user.Ad = model.Ad;
                user.Soyad = model.Soyad;
                user.Sifre = model.Sifre;
                user.Email = model.Email;
                try
                {
                    result = _autoService.Register(user, model.Sifre);
                    if (result.Success)
                    {
                        var resultToken =_autoService.CreateAccessToken(result.Data);
                        HttpContext.Session.SetString("UserId", result.Data.Id.ToString());
                    }
                }
                catch (Exception e)
                {
                    result = new ErrorDataResult<User>(null, e.Message.ToString());
                }
            }
            else
            {
                result = new ErrorDataResult<User>(null, "Sözleşmeyi onaylamanız gerekmektedir.");
            }
            return Json(result);
        }

        public IActionResult GirisYap()
        {
            UserForLoginDto login = new UserForLoginDto();
            return View(login);
        }

        [HttpPost]
        public IActionResult GirisYap(UserForLoginDto model)
        {
            IDataResult<User> result = null;
            try
            {
                result = _autoService.Login(model);
                if (result.Success)
                {
                    var resultToken = _autoService.CreateAccessToken(result.Data);
                    HttpContext.Session.SetString("UserId", result.Data.Id.ToString());
                }
            }
            catch (Exception e)
            {
                result = new ErrorDataResult<User>(e.Message);
            }
            return Json(result);
        }
    }
}
