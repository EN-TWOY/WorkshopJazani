namespace Jazani.Application.Cores.Services;

public interface IQueryService<TDtoSmall, TDto>
{
    Task<IReadOnlyList<TDtoSmall>> FindAllAsync();

    Task<TDto> FindByIdAsync(int id);
}