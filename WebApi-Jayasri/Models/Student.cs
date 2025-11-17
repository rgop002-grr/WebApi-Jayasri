using System;
using System.Collections.Generic;

namespace WebApi_Jayasri.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual StudentAddress? StudentAddress { get; set; }
}
