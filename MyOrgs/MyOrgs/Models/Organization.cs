using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MyOrgs.Models
{
    public class Organization
    {
        [Key]
        public int OrgID { get; set; }

        [Required]
        public string orgName { get; set; }

        [Required]
        public string orgDesc { get; set; }
    }
}
