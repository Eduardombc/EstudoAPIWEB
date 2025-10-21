using System.ComponentModel.DataAnnotations;

namespace EstudoAPIWEB.Data.DTOs;

public class CreateFilmeDTO
{

    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public string Titulo { get; set; }


    [Required(ErrorMessage = "O Genero do filme é obrigatório")]
    [StringLength(50, ErrorMessage = "O gênero do filme não pode exceder 50 caracteres")]
    public string Genero { get; set; }


    [Required(ErrorMessage = "O Duracao do filme é obrigatório")]
    [Range(70, 600, ErrorMessage = "A duração do filme deve estar entre 70 e 600 minutos")]
    public int Duracao { get; set; }

}
