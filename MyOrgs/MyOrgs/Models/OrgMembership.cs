using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MyOrgs.Models
{
    public class OrgMembership
    {
        [Required]
        public int Org { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string User { get; set; }
        //The following does not work
        //[Required]
        //public bool isManager { get; set; }
    }


}
