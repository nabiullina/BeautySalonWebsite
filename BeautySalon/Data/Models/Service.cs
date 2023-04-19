using System;
using System.Collections.Generic;

namespace BeautySalon.Data.Models;

public partial class Service
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? About { get; set; }

    public long? Posid { get; set; }

    public virtual Position? Pos { get; set; }

    public virtual ICollection<Serviceprovision> Serviceprovisions { get; set; } = new List<Serviceprovision>();
}
