using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{

    public class PersonDetails
    {
        public int id { get; set; }
        public string PersonName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string gender { get; set; }
    }
}
