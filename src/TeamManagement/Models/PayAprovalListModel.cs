using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamManagement.Models
{
    public class PayAprovalListModel
    {
        public string Institute { get; set; }
        public string Branch { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Class { get; set; }
        public string TotalStudent { get; set; }
        public string FeeperStudent { get; set; }
        public string TotalCost { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public string Tranjection { get; set; }
        public string Approved { get; set; }
        public string GrantedMember { get; set; }
        public string PayDate { get; set; }
    }
}