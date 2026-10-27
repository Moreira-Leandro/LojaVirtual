using Domain.Entities;
using Domain.Interfaces;
using ERP.Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers;

[ApiController]
[Route("api/produtos")]
public class ProdutoController(IProdutoRepository repository) : ControllerBase
{
    
    // POST
    [HttpPost]
    public async Task<IActionResult> Criar(ProdutoCreateRequest request)
    {
        Produto produto = new Produto(request.nome, request.preco, request.estoque);
        int id = await repository.CriarAsync(produto);
        
        return Created($"api/produtos/{id}", new {id});
    }
}