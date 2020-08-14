﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace CaimanProject.Models
{
    public class Projet
    {
        [Key]
        public int ProjetId { get; set; }

        public string ProjetName { get; set; }

        public DateTime ProjetDateDebut { get; set; }
        public DateTime ProjetDateFin { get; set; }

        public string ProjetDescription { get; set; }

        public int ProjetProgressBar { get; set; }
        public string ProjetCahierCharge { get; set; }
        public int ProjetMoney { get; set; }

        //recuper tous les membres qui sont dans le projet 
        public ICollection<Member> Members { get; set; }
        //Recupere toutes les notes sur le projets
        public ICollection<NoteP> NotePs { get; set; }
    }
}