using System.ComponentModel.DataAnnotations;

namespace EstudoAPIWEB.Models;

/// <summary>
/// Represents a movie with properties for its title, genre, and duration.
/// </summary>
/// <remarks>This class is used to store and manage information about a movie, including its unique identifier,
/// title, genre, and duration. All properties are required and include validation attributes to ensure data
/// integrity.</remarks>
public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }


    [Required (ErrorMessage = "O título do filme é obrigatório" )]
    public string Titulo { get; set; }


    [Required (ErrorMessage = "O Genero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O gênero do filme não pode exceder 50 caracteres")]
    public string Genero { get; set; }


    [Required (ErrorMessage = "O Duracao do filme é obrigatório")]
    [Range(70,600, ErrorMessage = "A duração do filme deve estar entre 70 e 600 minutos")]
    public int Duracao { get; set; }
    
}
