using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public string MemberMail { get; set; }

        public int MemberPhone { get; set; }

        public string MemberImageName { get; set; }

        public bool? MemberIsArchived { get; set; }

        public string MemberStatus { get; set; }

        public string MemberCommune { get; set; }

        public string MemberQuartier { get; set; }

        public int MemberMissonFin { get; set; }

        public int MemberMissionActive { get; set; }

        public int MemberNote { get; set; }
        
        public string Specialite { get; set; }

        public string Transport { get; set; }

    }


}