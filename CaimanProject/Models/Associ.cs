using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaimanProject.Models
{
    public class Associ
    {
        public int ProjetId { get; set; }
        public int MemberId { get; set; }
        public Projet Projet { get; set; }
        public Member Member{ get; set; }
    }
}