using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MyOrgs.Models
{
    public class Announcement
    {
        public int AnnouncementID { get; set; }

        [Required]
        public string Headline { get; set; }
        [Required]
        //This should get the organization that posted it
        public string Author { get; set; }

        [DataType(DataType.Date)]
        public DateTime publishDate { get; set; }

        [Required]
        //The Announcement itself
        public string post { get; set; }
    }
}
