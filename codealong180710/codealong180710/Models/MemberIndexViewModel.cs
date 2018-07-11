using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace codealong180710.Models
{
    public class MemberIndexViewModel
    {
        public List<Member> Members { get; set; }
        public string SearchString { get; set; }
        public string SearchField { get; set; }
    }
}