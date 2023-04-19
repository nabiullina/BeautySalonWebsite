using System;
using System.Collections.Generic;

namespace BeautySalon.Data.Models;

public partial class Position
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<Employee> Emps { get; set; } = new List<Employee>();
}
