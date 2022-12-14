// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bookware.Models
{
    [Table("Student")]
    public partial class Student
    {
        [Key]
        [Column("Student_Id")]
        public int StudentId { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string StudentName { get; set; }
        [Required]
        [StringLength(70)]
        [Unicode(false)]
        public string Address { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column("Class_Id")]
        public int? ClassId { get; set; }

        [ForeignKey("ClassId")]
        [InverseProperty("Students")]
        public virtual Class Class { get; set; }
    }
}