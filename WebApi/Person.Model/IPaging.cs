using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Model
{
    public interface IPaging
    {
        int? PageNumber { get; set; }
        int? NumberPerPage { get; set; }
    }
}
