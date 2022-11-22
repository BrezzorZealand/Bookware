﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bookware.Models
{
    [Table("Class")]
    public partial class Class
    {
        public Class()
        {
            ClassBooks = new HashSet<ClassBook>();
        }

        [Key]
        [Column("Class_Id")]
        public int ClassId { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string ClassName { get; set; }
        public int Term { get; set; }
        [Column("EduSub_Id")]
        public int EduSubId { get; set; }
        [Column("TeacherSub_Id")]
        public int TeacherSubId { get; set; }
        [Column("Student_Id")]
        public int StudentId { get; set; }

        [ForeignKey("EduSubId")]
        [InverseProperty("Classes")]
        public virtual EducationSubject EduSub { get; set; }
        [ForeignKey("StudentId")]
        [InverseProperty("Classes")]
        public virtual Student Student { get; set; }
        [ForeignKey("TeacherSubId")]
        [InverseProperty("Classes")]
        public virtual TeacherSubject TeacherSub { get; set; }
        [InverseProperty("Class")]
        public virtual ICollection<ClassBook> ClassBooks { get; set; }
    }
}