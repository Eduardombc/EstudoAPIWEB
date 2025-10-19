using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstudoAPIWEB.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id = ++id;
        filmes.Add(filme);
        return CreatedAtAction(nameof(RecuperaFilmesPorID),
            new { id = filme.Id },
            filme);
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip = 0, 
        [FromQuery] int take = 10)
    {
        return filmes.Skip(skip).Take(take);
    }
    public IActionResult RecuperaFilmesPorID(int id)
    {
        var filme = filmes.FirstOrDefault( f => f.Id == id);
        if (filme is null) return NotFound(); 
            return Ok(filme);
    }

    [HttpDelete]
    public IActionResult DeletaFilme(int id)
    {
        var filme = filmes.FirstOrDefault(f => f.Id == id);
        if (filme is null) return NotFound();
        filmes.Remove(filme);
        return NoContent();
    }
}
