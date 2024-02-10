using System;
namespace Jazani.Application.Admins.Dtos.Areas
{
	public class AreaSaveDto
	{
        public int AreaTypeId { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}

