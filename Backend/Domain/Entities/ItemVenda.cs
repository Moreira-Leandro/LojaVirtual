namespace Domain.Entities;

public class ItemVenda
{
    
    public int Id { get; private set; }
    public int VendaId { get; private set; }
    public Venda Venda { get; private set; } = null!;
    
    public int ProdutoId { get; private set; }
    public Produto Produto { get; private set; } = null!;
    public int Quantidade { get; private set; }
    public decimal PrecoUnitario { get; private set; }
    
    private ItemVenda() {}
    
    internal ItemVenda(int produtoId, int quantidade, decimal precoUnitario)
    {
        ProdutoId = produtoId;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
    }
    
}