using Jazani.Application.Admins.Dtos.AreaTypes;

namespace Jazani.Application.Admins.Dtos.Areas
{
	public class AreaDto
	{
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        // Relations
        public virtual AreaTypeSmallDto? AreaType { get; set; }
    }
}

