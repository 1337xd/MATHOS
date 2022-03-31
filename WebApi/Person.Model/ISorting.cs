using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Model
{
    public interface ISorting
    {
        string SortOrder { get; set; }
        string SortBy { get; set; }
    }
}
