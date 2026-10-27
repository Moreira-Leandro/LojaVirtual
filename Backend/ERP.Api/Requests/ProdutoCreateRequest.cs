namespace ERP.Api.Requests;

public record ProdutoCreateRequest(string nome, decimal preco, int estoque);