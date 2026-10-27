using Domain.Entities;
using Npgsql;

namespace Infrastructure.Mappers;

public class ProdutoMap
{
    public static Produto MapearProduto(NpgsqlDataReader reader)
    {
        var produto = new Produto(
            reader.GetString(reader.GetOrdinal("Nome")),
            reader.GetDecimal(reader.GetOrdinal("Preco")),
            reader.GetInt32(reader.GetOrdinal("Estoque"))
        );

        return produto;
    }
    
}