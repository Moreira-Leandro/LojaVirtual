using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Mappers;
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

    public async Task<Produto?> BuscarPorIdAsync(int id)
    {
        string query = "SELECT id, nome, preco, estoque, status FROM produtos WHERE id=@id;";

        await using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using NpgsqlCommand command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("id", id);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        return ProdutoMap.MapearProduto(reader);
    }

    public async Task<List<Produto>> BuscarTodosAsync()
    {

        List<Produto> produtos = [];
        
        string query = "SELECT id, nome, preco, estoque, status FROM produtos";

        await using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        using NpgsqlCommand command = new NpgsqlCommand(query, connection);
        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            Produto produto = ProdutoMap.MapearProduto(reader);
            produtos.Add(produto);
        }

        return produtos;
    }

    public async Task<List<Produto>> BuscarAtivosAsync()
    {

        List<Produto> produtos = [];
        
        string query = "SELECT * FROM produtos WHERE status = 1";

        await using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        using NpgsqlCommand command = new NpgsqlCommand(query, connection);
        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            Produto produto = ProdutoMap.MapearProduto(reader);
            produtos.Add(produto);
        }

        return produtos;

    }

    public Task AtualizarAsync(Produto produto)
    {
        throw new NotImplementedException();
    }
}