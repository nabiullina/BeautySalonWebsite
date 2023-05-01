namespace BeautySalon.Data.Models;

public class EmployeesOnPosition
{
    public long Empid { get; set; }
    public long Posid { get; set; }
    
    public Employee Emp { get; set; }
    public Position Pos { get; set; }

}