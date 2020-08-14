using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaimanProject.Models
{
    public class Associ
    {
        public Projet Projet { get; set; }
        public int ProjetId { get; set; }

        public Member Member { get; set; }
        public int MemberId { get; set; }
    }
}