using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSoft.Web.ViewModels
{
    public class SearchUserViewModel
    {
        public int? Page { get; set; }        
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public IPagedList<UserInfoListViewModel> SearchResults { get; set; }
        public string SearchButton { get; set; }
    }
}