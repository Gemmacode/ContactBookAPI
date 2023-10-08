using ContactBookModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookModel.ViewModels
{
    public class PaginatedUser
    {
        public int TotalUser { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<User> users { get; set; }
    }
}
