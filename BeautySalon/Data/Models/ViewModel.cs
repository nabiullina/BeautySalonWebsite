namespace BeautySalon.Data.Models;

public class ViewModel
{
    public Employee? Employee { get; set; }
    public EmployeesOnPosition? EmployeesOnPosition { get; set; }
    public Schedule? Schedule { get; set; }
    public Serviceprovision? Serviceprovision { get; set; }
    public Client? Client { get; set; }
    public Service? Service { get; set; }
}