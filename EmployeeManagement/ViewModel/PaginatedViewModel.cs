using System.Collections.Generic;
using EmployeeManagement.Models;

namespace EmployeeManagement.ViewModel
{
    public class PaginatedViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}
