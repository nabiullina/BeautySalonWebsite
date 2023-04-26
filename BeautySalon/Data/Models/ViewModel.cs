namespace BeautySalon.Data.Models;

public class ViewModel
{
    public Employee Employee { get; set; } = null!;
    public Position Position { get; set; } = null!;
    public EmployeesOnPosition EmployeesOnPosition { get; set; } = null!;
}