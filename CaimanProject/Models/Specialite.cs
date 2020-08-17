using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaimanProject.Models
{
    public class Specialite
    {
        [Key]
        public int SpecialiteId { get; set; }

        public string SpecialiteName { get; set; }

        public string SpecialiteColor { get; set; }
        public string SpecialiteDescription { get; set; }
        public string ImageSpecialité { get; set; }
        public string Url_Image { get; set; }
       
    }
}