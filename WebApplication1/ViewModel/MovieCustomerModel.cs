using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;


namespace WebApplication1.ViewModel
{
    public class MovieCustomerModel
    { public Customer Cust { get; set; }
       

     public List<movie> Movies { get; set; }  
    }
}