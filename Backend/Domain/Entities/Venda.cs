using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public class Venda
{
    
    public int Id { get; private set; }
    public decimal ValorTotal { get; private set; }
    private readonly List<ItemVenda> _itens = new();
    public IReadOnlyCollection<ItemVenda> Itens => _itens;
    public StatusVenda Status { get; private set; }
    public DateTime DataVenda { get; private set; } = DateTime.UtcNow;
    public Usuario Usuario { get; private set; } = null!;
    public int UsuarioId { get; private set; }

    private Venda() {}

    public Venda(int usuarioId)
    {
        UsuarioId = usuarioId;
    }
    
    private void CalcularTotal()
    {
        ValorTotal = Itens.Sum(i => i.PrecoUnitario * i.Quantidade);
    }

    public void AdicionarItem(Produto produto, int quantidade)
    {
        if (quantidade <= 0)
            throw new DomainException("Quantidade inválida");
        if (Status != StatusVenda.Pendente)
            throw new DomainException("Venda já consolidada");
        
        _itens.Add(new ItemVenda(produto.Id, quantidade, produto.Preco));
        CalcularTotal();
    }
    
    public void Cancelar()
    {
        if (Status == StatusVenda.Cancelada)
            throw new DomainException("Venda já cancelada");
        if (Status == StatusVenda.Concluida)
            throw new DomainException("Venda já concluída");
        
        Status = StatusVenda.Cancelada;
    }

    public void Concluir()
    {
        if (Status != StatusVenda.Paga)
            throw new DomainException("Apenas vendas pagas podem ser concluídas");
        Status = StatusVenda.Concluida;
    }

    public void ConfirmarPagamento()
    {
        if (Status != StatusVenda.Pendente)
            throw new DomainException("Venda concluída, paga ou cancelada");
        if (_itens.Count == 0)
            throw new DomainException("Não existe itens nessa venda");
        
        Status = StatusVenda.Paga;
    }
    
    
}