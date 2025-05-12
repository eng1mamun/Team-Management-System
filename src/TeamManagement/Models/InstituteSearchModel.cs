using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamManagement.Models
{
    public class InstituteSearchModel
    {
        public int InstituteId { get; set; }
        public string InsName { get; set; }
        public string InsShortName { get; set; }
        public string Status { get; set; }
        public string GrantedMember { get; set; }

    }
}