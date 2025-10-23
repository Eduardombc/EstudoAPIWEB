using System.ComponentModel.DataAnnotations;

namespace EstudoAPIWEB.Data.DTOs;

public class UpdateEnderecoDTO
{
    [Required(ErrorMessage = "O logradouro é obrigatório")]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "O numero é obrigatório")]
    public int Numero { get; set; }
}
