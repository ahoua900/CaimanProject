using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaimanProject.Models
{
    public class ModeNote
    {
        public List<NoteP> NotePs { get; set; }
        public Projet Projets { get; set; }
    }
}