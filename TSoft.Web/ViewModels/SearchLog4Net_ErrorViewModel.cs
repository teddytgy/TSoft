using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSoft.Web.ViewModels
{
    public class SearchLog4Net_ErrorViewModel
    {
        public int? Page { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public IPagedList<Log4Net_ErrorListViewModel> SearchResults { get; set; }
        public string SearchButton { get; set; }
    }
}