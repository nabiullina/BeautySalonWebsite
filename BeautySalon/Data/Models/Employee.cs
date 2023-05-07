using System;
using System.Collections.Generic;

namespace BeautySalon.Data.Models;

public partial class Employee
{
    public long Id { get; set; }

    public string Surname { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string FathersName { get; set; } = null!;

    public long? Phone { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    
    public virtual ICollection<EmployeesOnPosition> EmployeesOnPositions { get; set; } = new List<EmployeesOnPosition>();
    
}
