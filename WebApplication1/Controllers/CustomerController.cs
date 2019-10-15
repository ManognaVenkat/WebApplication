using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModel;
using System.Data.Entity;



namespace WebApplication1.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext dbContext = null;
        public CustomerController()
        {
            dbContext = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }
        [AllowAnonymous]
        public ActionResult Index()
        {


            var customers = dbContext.Customers.Include(m => m.MembershipType).ToList();
            return View("CustomerView", customers);

        }
        public ActionResult Details1(int id)
        {
            var customer = dbContext.Customers.Include(c => c.MembershipType).ToList().SingleOrDefault(a => a.Id == id);
            return View(customer);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var Customers = new Customer();

            ViewBag.Gender = ListGender();

            ViewBag.MembershipTypeId = ListMembership();
            return View(Customers);
        }
        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            var customer = dbContext.Customers.SingleOrDefault(c => c.Id==id);
            if(customer != null)
            {
               
                ViewBag.Gender = ListGender();
                ViewBag.MembershipTypeId = ListMembership();
                return View(customer);
            }
            return HttpNotFound("Customer not available");
        }
        [HttpPost]
        public ActionResult EditCustomer(Customer CustomerFromView)
        {
            if(ModelState.IsValid)
            {
                var CustomerInDb = dbContext.Customers.FirstOrDefault(c => c.Id == CustomerFromView.Id);
                CustomerInDb.Name = CustomerFromView.Name;
                CustomerInDb.Gender = CustomerFromView.Gender;
                CustomerInDb.BirthDate = CustomerFromView.BirthDate;
                CustomerInDb.MembershipType = CustomerFromView.MembershipType;
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ViewBag.Gender = ListGender();
                ViewBag.MembershipTypeId = ListMembership();
                return View(CustomerFromView);
            }
        }
        [HttpPost]
        public ActionResult Create(Customer CustomerFromView)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.Gender = ListGender();
                ViewBag.MembershipTypeId = ListMembership();
                return View(CustomerFromView);
            }
            dbContext.Customers.Add(CustomerFromView);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Customer");

        }
        public IEnumerable<SelectListItem> ListGender()
        {
            var gender = new List<SelectListItem>
            {
                new SelectListItem{Text="Select a gender",Value="0",Disabled=true,Selected=true},
                new SelectListItem{Text="Male"},
                new SelectListItem{Text="Others"},
                new SelectListItem{Text="Female"}
            };
            return gender;
        }
        [NonAction]
        public IEnumerable<SelectListItem> ListMembership()
        {

            var membership = (from m in dbContext.MembershipTypes.AsEnumerable()

                              select new SelectListItem
                              {
                                  Text = m.Type,
                                  Value = m.ID.ToString(),
                              }).ToList();
            membership.Insert(0, new SelectListItem { Text = "---Select--", Value = "0", Disabled = true, Selected = true });

            //var membership1 = dbContext.MembershipTypes.AsEnumerable()
            //    .Select(n => new SelectListItem() { Text = n.Type, Value = n.ID.ToString() });

            return membership;
        }
        [HttpGet]
        public ActionResult DeleteConfirmed(int? id)
        {
            var cd1 = dbContext.Customers.SingleOrDefault(C => C.Id == id);
            if (id == null)
            {
                return HttpNotFound();
            }
            Customer cd = dbContext.Customers.Find(id);
            if (cd == null)
            {
                return HttpNotFound();
            }
            return View(cd);
        }

       
        [HttpPost]
       
        public ActionResult DeleteConfirmed(int id)
        {
            Customer cd = dbContext.Customers.Find(id);
            dbContext.Customers.Remove(cd);
            dbContext.SaveChanges();
            return RedirectToAction("Index","Customer");
        }
        public ActionResult CustomerView()
        {
            MovieCustomerModel vm = new MovieCustomerModel();
            Customer c1 = new Customer { Name = "mano" };
            List<movie> m = new List<movie>
            {
                new movie{MovieName="KGF",theatre="PVR",id=345},
                new movie{MovieName="AR",theatre="inox",id=456}
            };
            vm.Cust = c1;
            vm.Movies = m;
            return View(vm);


        }
    }
}