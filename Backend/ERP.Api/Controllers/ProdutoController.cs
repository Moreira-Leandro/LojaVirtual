using Domain.Entities;
using Domain.Interfaces;
using ERP.Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers;

[ApiController]
[Route("api/produtos")]
public class ProdutoController(IProdutoRepository repository) : ControllerBase
{
    
    // CRIAR PRODUTO
    [HttpPost]
    public async Task<IActionResult> Criar(ProdutoCreateRequest request)
    {
        Produto produto = new Produto(request.nome, request.preco, request.estoque);
        int id = await repository.CriarAsync(produto);
        
        return Created($"api/produtos/{id}", new {id});
    }
    
    // BUSCAR PRODUTO POR ID
    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        Produto produto = await repository.BuscarPorIdAsync(id);

        if (produto == null)
            return NotFound("Produto não encontrado");

        return Ok(produto);
    }
    
    // BUSCAR TODOS OS PRODUTOS
    [HttpGet]
    public async Task<IActionResult> BuscarTodos()
    {
        List<Produto> produtos = await repository.BuscarTodosAsync();

        if (produtos.Count == 0)
            return NotFound("Nenhum item encontrado");

        return Ok(produtos);
    }
    
    // BUSCAR PRODUTOS ATIVOS
    [HttpGet("ativos")]
    public async Task<IActionResult> BuscarTodosAtivos()
    {
        List<Produto> produtos = await repository.BuscarAtivosAsync();

        if (produtos.Count == 0)
            return NotFound("Nenhum produto ativo");

        return Ok(produtos);
    }
    
}