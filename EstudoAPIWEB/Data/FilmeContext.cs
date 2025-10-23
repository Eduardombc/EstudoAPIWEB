using EstudoAPIWEB.Models;
using Microsoft.EntityFrameworkCore;

namespace EstudoAPIWEB.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
    {
        
    }
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
}
