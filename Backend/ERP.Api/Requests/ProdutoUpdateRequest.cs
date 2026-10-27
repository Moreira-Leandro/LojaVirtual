using Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ERP.Api.Requests;

public record ProdutoUpdateRequest(string nome, decimal preco, int estoque, StatusProduto status);