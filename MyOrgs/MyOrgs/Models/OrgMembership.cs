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
        public int Org;
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string User;
        [Required]
        public bool isManager;
    }


}
