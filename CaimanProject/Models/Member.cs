using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace CaimanProject.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        public string MemberName { get; set; }

        public string MemberPnom { get; set; }

        public string MemberSex { get; set; }

        public string MemberDescription { get; set; }

        public DateTime MemberNaissance { get; set; }

        public string MemberLieuNaissance { get; set; }

        [EmailAddress]
        public string MemberMail { get; set; }

        [Phone]
        public int MemberPhone { get; set; }

        public string MemberImageName { get; set; }

        public bool? MemberIsArchived { get; set; }

        public string MemberStatus { get; set; }

        public string MemberCommune { get; set; }

        public string MemberQuartier { get; set; }

        public int MemberMissonFin { get; set; }

        public int MemberMissionActive { get; set; }

        public int MemberNote { get; set; }
        // recupere la liste des reseaux sociaux du membre
        public ICollection<SocialNetwork> SocialNetworks { get; set; }

        //recupere un transport
        public Transport Transport { get; set; }

        //Recupere la liste des projet dont le membre participe
        public ICollection<Projet> Projets { get; set; }

        //Recupete la specialite dont le membre fait partie
        public Specialite Specialite { get; set; }

        //la recuperation de la liste des competences
        public ICollection<Competence> Competences { get; set; }

    }


}