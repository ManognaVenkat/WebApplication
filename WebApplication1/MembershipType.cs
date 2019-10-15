using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class MembershipType
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public short Duration { get; set; }
        public double SignupFee { get; set; }
        public short Discount { get; set; }

    }
}