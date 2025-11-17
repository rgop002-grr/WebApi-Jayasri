using System;
using System.Collections.Generic;

namespace WebApi_Jayasri.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public decimal? Salary { get; set; }

    public int? DeptId { get; set; }

    public virtual Department? Dept { get; set; }
}
