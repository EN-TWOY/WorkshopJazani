using Jazani.Application.Admins.Dtos.Areas;
using Jazani.Application.Admins.Dtos.Offices;

namespace Jazani.Application.Admins.Dtos.Managements;

public class ManagementDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int SectorsInCharge { get; set; }
    public decimal AnnualBudget { get; set; }
    public DateTime CreationDate { get; set; }
    public string Tasks { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool State { get; set; }
    
    public virtual AreaMediumDto? Area { get; set; }
    public virtual OfficeSmallDto? Office { get; set; }
}