namespace BeautySalon.Data.Models;

public class EmployeesOnPosition
{
    public long Empid { get; set; }
    public long Posid { get; set; }
    
    public virtual Employee Emp { get; set; } = null!;
    public virtual Position Pos { get; set; } = null!;

}