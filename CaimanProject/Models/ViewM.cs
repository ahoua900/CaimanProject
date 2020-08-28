using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaimanProject.Models
{
    public class ViewM
    {
        public Projet Projets { get; set; }
        public Member Members { get; set; }
        public List<NoteP> notePs { get; set; }
        public List<Competence> Competences { get; set; }
        public List<Member> Membre { get; set; }

        public List<Associ> Associs { get; set; }
    }

}