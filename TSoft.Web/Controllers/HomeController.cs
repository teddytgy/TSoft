using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using TSoft.Data;
using TSoft.Entities.Models;
using TSoft.Repository;
using TSoft.Web.ViewModels;
using Microsoft.Ajax.Utilities;
using PagedList;
using TSoft.Repository.Interfaces;
using MvcBreadCrumbs;
using Postal;

namespace TSoft.Web.Controllers
{
    [BreadCrumb]
    public class HomeController : Controller
    {
        readonly IUnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Agape Dental Studio";

            return View();
        }

        public ActionResult About()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("About", "Home"), "About");
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("Contact", "Home"), "Contact");
            ViewBag.Message = "Your contact page.";

            return View("Contact", "_AdsLayout1");
        }

        [HttpPost]

        public ActionResult Send(EmailViewModel model)
        {
            dynamic email = new Email("Basic");
            email.Name = model.FullName;
            email.Subject = model.Subject;
            email.ToEmail = "info@agapedentalstudio.com";
            email.Message = model.Message;
            email.FromEmail = model.FromEmail;
            email.Send();
            return RedirectToAction("contact"); 
        }

        [HttpPost]
        public ActionResult ContactForm(EmailViewModel model)
        {
            dynamic email = new Email("Basic");
            email.Name = model.FullName;
            email.Subject = model.Subject;
            email.ToEmail = "info@agapedentalstudio.com";
            email.Message = model.Message;
            email.FromEmail = model.FromEmail;
            email.Send();
            return RedirectToAction("Index");
        }

        public ActionResult ViewContactForm()
        {
            return PartialView("_ContactForm");
        }

        [HttpPost]
        public ActionResult Subscribe(EmailViewModel model)
        {
            dynamic email = new Email("Basic");
            email.Name = model.FullName;
            email.Subject = "Subscribe Monthly Newsletter";
            email.ToEmail = "info@agapedentalstudio.com";
            email.Message = model.Message;
            email.FromEmail = model.FromEmail;
            email.Send();
            return RedirectToAction("Index");
        }

        public ActionResult ViewSubscribe()
        {
            return PartialView("_Subscribe");
        }        

        public ActionResult ManageUser(SearchUserViewModel model)
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("ManageUser", "Home"), "Manage User");

            var pageIndex = 1;

            if (!string.IsNullOrEmpty(model.SearchButton) || model.Page.HasValue)
            {
                pageIndex = model.Page ?? 1;
                model.SearchResults = _unitOfWork.UserProfile.GetAll()
                .Select(u => new UserInfoListViewModel()
                {
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Phone = u.Phone
                }).Where(c => (c.LastName.StartsWith(model.LastName) || string.IsNullOrEmpty(model.LastName))
                    && (c.Email.StartsWith(model.Email) || string.IsNullOrEmpty(model.Email)))
                  .OrderBy(o => o.LastName)
                 .ToPagedList(pageIndex, 15);
            }
            else
            {
                model.SearchResults = _unitOfWork.UserProfile.GetAll()
                .Select(u => new UserInfoListViewModel()
                {
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Phone = u.Phone
                }).Where(c => (c.LastName.StartsWith(model.LastName) || string.IsNullOrEmpty(model.LastName))
                    && (c.Email.StartsWith(model.Email) || string.IsNullOrEmpty(model.Email)))
                  .OrderBy(o => o.LastName)
                 .ToPagedList(pageIndex, 15);
            }
            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("_UserInfo", model)
                : View("ManageUser", "_AdsLayout1", model);
        }

        public ActionResult AdminManagedUser(int? page)
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AdminManagedUser", "Home"), "Manage User");

            var pageNumber = page ?? 1;

            var users = _unitOfWork.UserProfile.GetAll()
                .Select(u => new UserInfoListViewModel()
                {
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Phone = u.Phone
                })
                .OrderBy(u => u.LastName)
                .ToPagedList(pageNumber, 10);
            return View(users);
        }
        
        public ActionResult OurPhilosophy()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("OurPhilosophy", "Home"), "Our Philosophy");
            return View("OurPhilosophy", "_AdsLayout1");
        }

        public ActionResult MeettheDoctors()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("MeettheDoctors", "Home"), "Meet Dr. Tekle");
            return View("MeettheDoctors", "_AdsLayout1");
        }

        public ActionResult PhotoGallery()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("PhotoGallery", "Home"), "Photo Gallery");
            return View("PhotoGallery", "_AdsLayout1");
        }

        public ActionResult MeetOurStaff()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("MeetOurStaff", "Home"), "Meet Our Staff");
            return View("MeetOurStaff", "_AdsLayout1");
        }
    }
}
