namespace Jazani.Application.Cores.Services;

public interface ICommandService<TDtoSimple, TDtoSave, ID>
{
    Task<TDtoSimple> CreateAsync(TDtoSave saveDto);

    Task<TDtoSimple> EditAsync(ID id, TDtoSave saveDto);

    Task<TDtoSimple> DisabledAsync(ID id);
}