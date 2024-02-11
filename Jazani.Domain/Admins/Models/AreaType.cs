namespace Jazani.Domain.Admins.Models
{
    public class AreaType
	{
		public int Id { get; set; }
		public string Name { get; set; } = default!;
		public string? Description { get; set; }
		public DateTime RegistrationDate { get; set; }
		public bool State { get; set; }

		// relations
		public virtual ICollection<Area> Areas { get; set; }
	}
}

