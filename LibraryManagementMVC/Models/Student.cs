using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace LibraryManagementMVC.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sid { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "Varchar")]
        [DisplayName("Name")]
        public string Sname { get; set; }
        public int Class { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoName {  get; set; }
        public byte[] Video { get; set; }
        public string VideoName { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}