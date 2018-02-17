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

namespace TSoft.Web.Controllers
{
    public class Log4Net_ErrorController : Controller
    {
        readonly IUnitOfWork _unitOfWork;

        public Log4Net_ErrorController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public Log4Net_ErrorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(SearchLog4Net_ErrorViewModel model)
        {
            var pageIndex = 1;

            if (!string.IsNullOrEmpty(model.SearchButton) || model.Page.HasValue)
            {
                pageIndex = model.Page ?? 1;
                model.SearchResults = _unitOfWork.Log4Net_Error.GetAll()
                .Select(u => new Log4Net_ErrorListViewModel()
                {
                    Level = u.Level,
                    Thread = u.Thread,
                    Logger = u.Logger,
                    Message = u.Message,
                    Date = u.Date
                }).Where(c => (c.Level.StartsWith(model.Level) || string.IsNullOrEmpty(model.Level))
                    && (c.Logger.StartsWith(model.Logger) || string.IsNullOrEmpty(model.Logger)))
                  .OrderBy(o => o.Level)
                 .ToPagedList(pageIndex, 15);
            }
            else
            {
                model.SearchResults = _unitOfWork.Log4Net_Error.GetAll()
                .Select(u => new Log4Net_ErrorListViewModel()
                {
                    Level = u.Level,
                    Thread = u.Thread,
                    Logger = u.Logger,
                    Message = u.Message,
                    Date = u.Date
                }).Where(c => (c.Level.StartsWith(model.Level) || string.IsNullOrEmpty(model.Level))
                    && (c.Logger.StartsWith(model.Logger) || string.IsNullOrEmpty(model.Logger)))
                  .OrderBy(o => o.Level)
                 .ToPagedList(pageIndex, 15);
            }
            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("_ErrorInfo", model)
                : View("Index", "_AdsLayout1", model);
        }           
    }
}
