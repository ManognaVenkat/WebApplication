using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            List<PersonDetails> p = Person();
            return View("PersonView",p);
        }
        public List<PersonDetails>  Person()
        {
            List<PersonDetails> Persons = new List<PersonDetails>
            {
                new PersonDetails{PersonName="mano",id=1,gender="female",DateOfBirth=DateTime.Now},
                new PersonDetails{PersonName="chotu",id=2,gender="female",DateOfBirth=DateTime.Now}
            };
            return Persons;

        }
        //public ActionResult Details(int id)
        //{
        //    PersonDetails p = new PersonDetails();
        //    var persons = Person();
        //    foreach( var customer in persons)
        //    {
        //        if (id == customer.id)
        //        {
        //            p = customer;
        //        }
        //    }
        //    return View("PersonView",p);
        //}
       
    }
}