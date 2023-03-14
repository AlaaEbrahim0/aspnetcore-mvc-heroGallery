using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Xml.Linq;
using Microsoft.AspNetCore.Localization;
using Microsoft.VisualBasic;

namespace EmployeeManagement.Utilites
{
    public class Pagination<T> where T : class
    {
        private readonly List<T> source;
        private readonly int pageSize;

        public Pagination(List<T> source, int pageSize)
        {
            this.source = source;
            this.pageSize = pageSize;
        }

        public List<T> GetPage(int page)
        {
            CurrentPage = page;
            return source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)source.Count / pageSize);

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;

        public int PreviousPage => HasPreviousPage ? CurrentPage - 1 : 1;

        public int NextPage => HasNextPage ? CurrentPage + 1 : TotalPages;

    }

}
