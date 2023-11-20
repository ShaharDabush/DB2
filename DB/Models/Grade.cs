using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DB.Models;

public partial class Grade
{
    [Key]
    public int GradeId { get; set; }

    public int Score { get; set; }

    public int StudentId { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("Grades")]
    public virtual Student Student { get; set; } = null!;
}
