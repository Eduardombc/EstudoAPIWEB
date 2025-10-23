using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace EstudoAPIWEB.Data.DTOs;

public class CreateEnderecoDTO
{
    [Required(ErrorMessage = "O logradouro é obrigatório")]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "O numero é obrigatório")]
    public int Numero { get; set; }
}
