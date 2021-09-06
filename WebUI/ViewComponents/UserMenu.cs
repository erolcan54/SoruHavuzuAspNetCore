using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewComponents
{    
    public class UserMenu:ViewComponent
    {
        private IUserService _userService;

        public UserMenu(IUserService userService)
        {
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            User user = _userService.GetById(userId).Data;

            return View(user);
        }
    }
}
