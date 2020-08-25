using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaimanProject.Models
{
    public class Associ
    {
        [Key]
        public int AssociKey { get; set; }
        public int ProjetId { get; set; }
        public int MemberId { get; set; }

    }
}