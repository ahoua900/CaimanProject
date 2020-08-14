using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaimanProject.Models
{
    public class Transport
    {
        [Key]
        public int TransportId { get; set; }

        public string TranportName { get; set; }

         //recupere la liste des membre qui ont le meme type de transport
        public ICollection<Member> Members { get; set; }
    }
}