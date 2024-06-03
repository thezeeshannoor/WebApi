using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Class { get; set; }

    public string? Number { get; set; }
}
