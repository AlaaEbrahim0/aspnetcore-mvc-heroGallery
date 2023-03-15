using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Xml.Linq;
using Microsoft.AspNetCore.Localization;
using Microsoft.VisualBasic;

namespace EmployeeManagement.ViewModel
{
    public class Pagination<T> where T : class
    {
        public IEnumerable<T> Users { get; set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public Pagination(IEnumerable<T> data, int pageNumber, int pageSize, int totalCount, int totalPages)
        {
            Users = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalPages;
        }

        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }


}
