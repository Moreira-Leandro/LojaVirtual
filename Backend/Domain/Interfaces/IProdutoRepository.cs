using Domain.Entities;

namespace Domain.Interfaces;

public interface IProdutoRepository
{
     
     Task<int> CriarAsync(Produto produto);
     Task<Produto?> BuscarPorIdAsync(int id);
     Task<List<Produto>> BuscarTodosAsync();
     Task<List<Produto>> BuscarAtivosAsync();
     Task AtualizarAsync(Produto produto);

}