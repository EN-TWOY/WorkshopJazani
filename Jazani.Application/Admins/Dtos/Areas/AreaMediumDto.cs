using Jazani.Application.Admins.Dtos.AreaTypes;

namespace Jazani.Application.Admins.Dtos.Areas;

public class AreaMediumDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    // Relations
    public virtual AreaTypeSmallDto? AreaType { get; set; }
}