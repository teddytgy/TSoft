using TSoft.Repository;
using TSoft.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TSoft.Web.Controllers
{
    public class BlogController : Controller
    {
        readonly IUnitOfWork _unitOfWork;

        public BlogController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public BlogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Blog()
        {
            return View();
        }
    }
}
