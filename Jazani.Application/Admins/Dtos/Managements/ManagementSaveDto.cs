namespace Jazani.Application.Admins.Dtos.Managements;

public class ManagementSaveDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int SectorsInCharge { get; set; }
    public decimal AnnualBudget { get; set; }
    public DateTime CreationDate { get; set; }
    public string Tasks { get; set; }
    public int AreaId { get; set; }
    public int OfficeId { get; set; }
}