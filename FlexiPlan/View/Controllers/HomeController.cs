using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace View.Controllers
{
    [NoCache]
    [Autorizacion]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}