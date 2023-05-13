namespace BeautySalon.Data.Models;

public class ViewModel
{
    public Employee? Employee { get; set; } = null!;
    public EmployeesOnPosition? EmployeesOnPosition { get; set; }
    public Schedule? Schedule { get; set; }
    public Serviceprovision? Serviceprovision { get; set; }
    public Client? Client { get; set; }
}