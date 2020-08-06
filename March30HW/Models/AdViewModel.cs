using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary2;

namespace March30HW.Models
{
    public class AdViewModel
    {
        public List<Ad> Ad { get; set; }
        public List<int> UserId { get; set; }
        public int? NextPage { get; set; }
        public int? PreviousPage { get; set; }
    }
}
