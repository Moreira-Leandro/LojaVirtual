using Domain.Entities;

namespace Domain.Interfaces;

public interface IUsuarioRepository
{

    Task CriarAsync(Usuario usuario);
    Task<Usuario?> BuscarPorIdAsync(int id);
    Task<Usuario?> BuscarPorEmailAsync(string email);
    Task AtualizarAsync(Usuario usuario);

}