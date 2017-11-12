using BusinessLogicApi.Business;
using BusinessLogicApi.DTO;
using BusinessLogicImpl.BusinessImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        IUserBusiness userBusiness = new UserBusiness();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult UserTable()
        {
            List<CreatedUser> users = userBusiness.FindAll();
            return PartialView(users);
        }

    }
}
