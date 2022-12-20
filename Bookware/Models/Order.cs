﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bookware.Models
{
    [Table("Order")]
    public partial class Order
    {
        [Key]
        [Column("Order_Id")]
        public int OrderId { get; set; }
        [Column("CB_Id")]
        public int CbId { get; set; }
        public int? Amount { get; set; }

        [ForeignKey("CbId")]
        [InverseProperty("Orders")]
        public virtual ClassBook Cb { get; set; }
    }
}