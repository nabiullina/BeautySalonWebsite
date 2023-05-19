using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.Data.Models;

public partial class Schedule
{
    public long Id { get; set; }
    
    [BindProperty, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime Date { get; set; }

    public char Status { get; set; }

    public long? Empid { get; set; }

    public virtual Employee? Emp { get; set; }

    public virtual Serviceprovision? Serviceprovision { get; set; }
}
