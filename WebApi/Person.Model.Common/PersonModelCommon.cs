using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person.Model;

namespace Person.Model.Common
{
    public interface PersonModelCommon
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        string Gender { get; set; }
    }
}
