using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SajiloAccount.Models;
//using AccountModel;
//using AccountBLL.Interfaces;
//using AccountBLL.Services;

namespace SajiloAccount.Controllers
{
    public class WebController : Controller
    {
        // ICRMService _iCRMService;
        //ReturnMessageModel rModel;
        //public WebController()
        //{
        //    _iCRMService = new CRMService();
        //    rModel = new ReturnMessageModel();
        //}
        //
        // GET: /Web/
        //[HttpPost]
        public ActionResult Index(bool passwordIssue = false)
        {
            ViewBag.IsPasswordIssue = passwordIssue;
            return View();
        }
        

        
       
    }
}