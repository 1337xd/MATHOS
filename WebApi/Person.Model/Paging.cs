using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Model
{
    public class Paging : IPaging
    {
        public int? PageNumber { get; set; }
        public int? NumberPerPage { get; set; }

        public Paging(int? pageNumber, int? numberPerPage)
        {
            PageNumber = pageNumber ?? 1;
            NumberPerPage = numberPerPage ?? 5;
        }
    }
}
