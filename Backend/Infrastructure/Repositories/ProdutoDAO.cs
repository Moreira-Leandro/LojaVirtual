using Domain.Entities;
using Domain.Interfaces;
using Npgsql;

namespace Infrastructure.Repositories;

public class ProdutoDAO : IProdutoRepository
{

    private string _connectionString;

    public ProdutoDAO(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<int> CriarAsync(Produto produto)
    {
        string query = "INSERT INTO produtos (nome, preco, estoque, status) VALUES (@nome, @preco, @estoque, @status) RETURNING id;";

        await using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using NpgsqlCommand command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("nome", produto.Nome);
        command.Parameters.AddWithValue("preco", produto.Preco);
        command.Parameters.AddWithValue("estoque", produto.Estoque);
        command.Parameters.AddWithValue("status", (short)produto.Status);

        return Convert.ToInt32(await command.ExecuteScalarAsync());

    }

    public Task<Produto?> BuscarPorIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Produto>> BuscarTodosAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Produto>> BuscarAtivosAsync()
    {
        throw new NotImplementedException();
    }

    public Task AtualizarAsync(Produto produto)
    {
        throw new NotImplementedException();
    }
}