using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstudoAPIWEB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private List<Filme> filmes = new List<Filme>();

        public void AdicionarFilme ([FromBody] Filme filme)
        {
            filmes.Add(filme);
        }
    }
}
