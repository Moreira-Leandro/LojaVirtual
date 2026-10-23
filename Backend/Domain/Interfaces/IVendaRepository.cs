using Domain.Entities;

namespace Domain.Interfaces;

public interface IVendaRepository
{

    Task CriarAsync(Venda venda);
    Task<Venda?> BuscarPorIdAsync(int id);
    Task<List<Venda>> BuscarTodosAsync();
    Task<List<Venda>> BuscarPorUsuarioAsync(int usuarioId);
    Task AtualizarAsync(Venda venda);

}