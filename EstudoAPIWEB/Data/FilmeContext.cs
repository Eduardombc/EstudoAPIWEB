using EstudoAPIWEB.Controllers;
using Microsoft.EntityFrameworkCore;

namespace EstudoAPIWEB.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
    {
        
    }
    public DbSet<Filme> Filmes { get; set; }

}
