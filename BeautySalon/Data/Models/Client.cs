using System;
using System.Collections.Generic;

namespace BeautySalon.Data.Models;

public partial class Client
{
    public long Id { get; set; }

    public string Surname { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string FathersName { get; set; } = null!;

    public decimal? Phone { get; set; }

    public virtual ICollection<Serviceprovision> Serviceprovisions { get; set; } = new List<Serviceprovision>();
}
