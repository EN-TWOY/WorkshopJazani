namespace Jazani.Domain.Admins.Models;

public class Management
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public int SectorsInCharge { get; set; }
    public decimal AnnualBudget { get; set; }
    public DateTime CreationDate { get; set; }
    public string? Tasks { get; set; }
    public int AreaId { get; set; }
    public int OfficeId { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool State { get; set; }
    
    public virtual Area? Area { get; set; }
    public virtual Office? Office { get; set; }
}