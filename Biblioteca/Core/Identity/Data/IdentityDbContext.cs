using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core.Identity.Data;

// Renomeando a classe para evitar conflito com outra definição de "IdentityContext"
public class CustomIdentityContext : IdentityDbContext<UsuarioIdentity>
{
    public CustomIdentityContext(DbContextOptions<CustomIdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Personalize o modelo de identidade do ASP.NET e substitua os padrões, se necessário.
        // Por exemplo, você pode renomear os nomes das tabelas de identidade do ASP.NET e muito mais.
        // Adicione suas personalizações após chamar base.OnModelCreating(builder);
    }
}
