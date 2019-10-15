using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class movie
    {
      
        public int id { get; set; }

        [Display(Name ="Your Movie")]
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string theatre { get; set; }
        [Required]
        public Genre Genres { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}