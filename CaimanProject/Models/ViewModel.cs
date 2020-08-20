using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaimanProject.Models
{
    public class ViewModel
    {
        public List<Specialite> Specialites { get; set; }
        public List<Member> Members { get; set; }
        public List<Projet> Projets { get; set; }
        
    }
}