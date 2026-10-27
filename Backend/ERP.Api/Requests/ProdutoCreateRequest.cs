namespace ERP.Api.Requests;

public record ProdutoCreateRequest(int id, string nome, decimal preco, int estoque);