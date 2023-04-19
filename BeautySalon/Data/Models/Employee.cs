using System;
using System.Collections.Generic;

namespace BeautySalon.Data.Models;

public partial class Employee
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Phone { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<Position> Pos { get; set; } = new List<Position>();
}
