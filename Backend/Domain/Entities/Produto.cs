using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public class Produto
{
    
    public int Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }
    public StatusProduto Status { get; private set; } = StatusProduto.Ativo;

    private Produto(){}

    public Produto(string nome, decimal preco, int estoque)
    {
        Validar(nome, preco);
        if (estoque < 0)
            throw new DomainException("Estoque não pode ser negativo");

        Nome = nome;
        Preco = preco;
        Estoque = estoque;
    }

    private static void Validar(string nome, decimal preco)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("Nome inválido");
        if (preco <= 0)
            throw new DomainException("Preço inválido");
    }
    
    public void Atualizar(string nome, decimal preco)
    {
        
        Validar(nome, preco);
        
        Nome = nome;
        Preco = preco;
    }

    public void Inativar()
    {
        if (Status == StatusProduto.Desativado)
            throw new DomainException("Produto já inativo");
        this.Status = StatusProduto.Desativado;
    }

    public void Ativar()
    {
        if (Status == StatusProduto.Ativo)
            throw new DomainException("Produto já ativo");
        Status = StatusProduto.Ativo;
    }
    
    public void BaixarEstoque(int quantidade)
    {
        if (quantidade <= 0)
            throw new DomainException("Quantidade deve ser maior que 0");
        if (quantidade > Estoque)
            throw new DomainException("Não possui itens o suficiente");
        if (Status == StatusProduto.Desativado)
            throw new DomainException("O produto está desativado");

        this.Estoque -= quantidade;
    }

    public void DevolverEstoque(int quantidade)
    {
        if (quantidade <= 0)
            throw new DomainException("Quantidade deve ser maior que 0");
        Estoque += quantidade;
    }
    
}