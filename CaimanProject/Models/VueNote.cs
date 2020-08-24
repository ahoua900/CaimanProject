using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaimanProject.Models
{
    public class VueNote
    {
        public NoteP NotePs { get; set; }
        public List<Projet> Projets { get; set; }
    }
}