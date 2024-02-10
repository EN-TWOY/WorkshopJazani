using System;
namespace Jazani.Application.Admins.Dtos.Areas
{
	public class AreaSmallDto
	{
        public int Id { get; set; }
        public int AreaTypeId { get; set; }
        public string Name { get; set; } = default!;
    }
}

