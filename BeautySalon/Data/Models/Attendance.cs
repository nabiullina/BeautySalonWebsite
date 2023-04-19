using System;
using System.Collections.Generic;

namespace BeautySalon.Data.Models;

public partial class Attendance
{
    public long Id { get; set; }

    public long? Clientid { get; set; }

    public virtual Client? Client { get; set; }

    public virtual ICollection<Serviceprovision> Serviceprovisions { get; set; } = new List<Serviceprovision>();
}
