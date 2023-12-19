using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace LibraryManagementMVC.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Bid { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "Varchar")]
        [DisplayName("Name")]
        public string Bname { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "Varchar")]
        public string Author { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "Varchar")]
        public string Publication { get; set; }
        [Column(TypeName ="Date")]
        public DateTime Year { get; set; }
    }
}