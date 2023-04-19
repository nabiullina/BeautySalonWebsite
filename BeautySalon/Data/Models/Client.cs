using System;
using System.Collections.Generic;

namespace BeautySalon.Data.Models;

public partial class Client
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Phone { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}
