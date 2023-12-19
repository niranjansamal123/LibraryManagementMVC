using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryManagementMVC.Models
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Rid {  get; set; }
        public int Sid { get; set; }
        public int Bid { get; set; }
        [DisplayName("Start Date")]
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }

        [ForeignKey("Sid")]
        public Student Student { get; set; }
        [ForeignKey("Bid")]
        public Book Book { get; set; }
    }
}