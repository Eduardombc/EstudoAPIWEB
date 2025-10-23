using AutoMapper;
using EstudoAPIWEB.Data;
using EstudoAPIWEB.Data.DTOs;
using EstudoAPIWEB.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EstudoAPIWEB.Controllers;

public class CinemaController : Controller
{
    private IMapper _mapper;

    private FilmeContext _context;

    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaCinema([FromBody] CreateCinemaDTO cinemaDTO)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaCinemasPorID),
            new { id = cinema.Id },
            cinema);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDTO> RecuperaCinemas([FromQuery] int skip = 0,
        [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadCinemaDTO>>(_context.Cinemas.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaCinemasPorID(int id)
    {
        var Cinema = _context.Cinemas.FirstOrDefault(f => f.Id == id);
        if (Cinema is null) return NotFound();
        var CinemaDTO = _mapper.Map<ReadCinemaDTO>(Cinema);
        return Ok(Cinema);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDTO CinemaDTO)
    {
        var Cinema = _context.Cinemas.FirstOrDefault(f => f.Id == id);
        if (Cinema is null) return NotFound();
        _mapper.Map(CinemaDTO, Cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaCinemaPartial(int id, JsonPatchDocument<UpdateCinemaDTO> patch)
    {
        var Cinema = _context.Cinemas.FirstOrDefault(f => f.Id == id);
        if (Cinema is null) return NotFound();

        var CinemaParaAtualizar = _mapper.Map<UpdateCinemaDTO>(Cinema);
        if (!TryValidateModel(CinemaParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(CinemaParaAtualizar, Cinema);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaCinema(int id)
    {
        var Cinema = _context.Cinemas.FirstOrDefault(f => f.Id == id);
        if (Cinema is null) return NotFound();
        _context.Cinemas.Remove(Cinema);
        _context.SaveChanges();
        return NoContent();
    }
}
