using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_DBM.Models
{
    public class SchoolItem
    {
        public class Person
        {
            public int id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime Birthday { get; set; }
            
        }
    }

}
