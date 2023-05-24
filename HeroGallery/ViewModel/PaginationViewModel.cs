using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Xml.Linq;
using Microsoft.AspNetCore.Localization;
using Microsoft.VisualBasic;

namespace HeroManagement.ViewModel
{
    public class Pagination<T> where T : class
    {
        public List<T> Data { get; set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public Pagination(List<T> data, int pageNumber, int pageSize, int totalCount, int totalPages)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalPages;
        }

        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }


}
