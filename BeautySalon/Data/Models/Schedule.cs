using System;
using System.Collections.Generic;

namespace BeautySalon.Data.Models;

public partial class Schedule
{
    public long Id { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    public char Status { get; set; }

    public long? Empid { get; set; }

    public virtual Employee? Emp { get; set; }

    public virtual ICollection<Serviceprovision> Serviceprovisions { get; set; } = new List<Serviceprovision>();
}
