using System;
using System.Collections.Generic;

namespace BeautySalon.Data.Models;

public partial class Serviceprovision
{
    public long Attid { get; set; }

    public long Serid { get; set; }

    public long? Schid { get; set; }

    public virtual Attendance Att { get; set; } = null!;

    public virtual Schedule? Sch { get; set; }

    public virtual Service Ser { get; set; } = null!;
}
