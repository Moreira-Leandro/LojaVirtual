using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public class Usuario
{
    
    public int Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string SenhaHash { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public PerfilUsuario Perfil { get; private set; } = PerfilUsuario.Cliente;
    
    private Usuario(){}

    public Usuario(string nome, string senhaHash, string email)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("Nome inválido");
        if (string.IsNullOrWhiteSpace(senhaHash))
            throw new DomainException("Senha inválida");
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("E-mail inválido");

        Nome = nome;
        SenhaHash = senhaHash;
        Email = email;

    }

    public void AtualizarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("Nome inválido");
        Nome = nome;
    }
    
    public void AtualizarSenha(string senhaHash)
    {
        if (string.IsNullOrWhiteSpace(senhaHash))
            throw new DomainException("Senha inválida");
        SenhaHash = senhaHash;
    }

}