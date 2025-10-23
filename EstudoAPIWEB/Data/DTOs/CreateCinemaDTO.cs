using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EstudoAPIWEB.Data.DTOs;

public class CreateCinemaDTO : Controller
{

    [Required(ErrorMessage = "O nome do cinema é obrigatório")]
    public string Nome { get; set; }

}
