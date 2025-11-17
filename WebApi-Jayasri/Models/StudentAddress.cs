using System;
using System.Collections.Generic;

namespace WebApi_Jayasri.Models;

public partial class StudentAddress
{
    public int StudentId { get; set; }

    public string AddressLine { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Pincode { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
