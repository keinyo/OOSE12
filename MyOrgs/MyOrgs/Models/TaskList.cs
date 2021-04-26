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
    public class TaskList
    {
        [Key]
        public int TaskID { get; set; }

        [Required]
        public string TaskName { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string User { get; set; }


        //Optional attributes
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public string ExtendedDescription { get; set; }

    }
}
