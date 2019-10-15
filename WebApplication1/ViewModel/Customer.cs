using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModel
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Your Name")]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime? BirthDate { get; set; }

        public virtual MembershipType MembershipType { get; set; }

        [Required]
        public int? MembershipTypeId { get; set; }

    }
}