using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class CustomerMovieViewModel
    {
        public movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}