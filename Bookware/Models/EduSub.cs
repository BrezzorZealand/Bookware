﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bookware.Models
{
    [Table("Edu_Sub")]
    public partial class EduSub
    {
        public EduSub()
        {
            TeacherEdus = new HashSet<TeacherEdu>();
        }

        [Key]
        [Column("EduSub_Id")]
        public int EduSubId { get; set; }
        [Column("Edu_Id")]
        public int EduId { get; set; }
        [Column("Subject_Id")]
        public int SubjectId { get; set; }

        [ForeignKey("EduId")]
        [InverseProperty("EduSubs")]
        public virtual Education Edu { get; set; }
        [ForeignKey("SubjectId")]
        [InverseProperty("EduSubs")]
        public virtual Subject Subject { get; set; }
        [InverseProperty("EduSub")]
        public virtual ICollection<TeacherEdu> TeacherEdus { get; set; }

    }
}