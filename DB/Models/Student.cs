using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DB.Models;

[Table("Student")]
public partial class Student
{
    [Key]
    public int StudentId { get; set; }

    [StringLength(20)]
    public string Name { get; set; } = null!;

    [InverseProperty("Student")]
    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
