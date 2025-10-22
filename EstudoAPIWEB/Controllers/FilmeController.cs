using AutoMapper;
using EstudoAPIWEB.Data;
using EstudoAPIWEB.Data.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstudoAPIWEB.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private IMapper _mapper;

    private FilmeContext _context;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDTO)
    {
        Filme filme = _mapper.Map<Filme>(filmeDTO);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmesPorID),
            new { id = filme.Id },
            filme);
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip = 0, 
        [FromQuery] int take = 10)
    {
        return _context.Filmes.Skip(skip).Take(take);
    }

    [HttpGet]
    public IActionResult RecuperaFilmesPorID(int id)
    {
        var filme = _context.Filmes.FirstOrDefault( f => f.Id == id);
        if (filme is null) return NotFound(); 
            return Ok(filme);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id,[FromBody] UpdateFilmeDTO filmeDTO)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme is null) return NotFound();
        _mapper.Map(filmeDTO, filme);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme is null) return NotFound();
        filmes.Remove(filme);
        return NoContent();
    }
}
