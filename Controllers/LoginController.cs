using QLMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLMT.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Login(LoginModel model)
        {
           
            return View("Index");
        }
    }
}