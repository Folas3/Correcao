using Correcao.Interfaces;
using Correcao.Models;
using Microsoft.AspNetCore.Mvc;

namespace Correcao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogadoresController : ControllerBase
    {
        private readonly IJogadorRepository repository;

        public JogadoresController(IJogadorRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] Jogador jogador)
        {
            if (repository.BuscarPorCpf(jogador.CPF) != null)
            {
                return BadRequest(
                    "Já existe um jogador cadastrado com esse CPF.");
            }

            repository.Adicionar(jogador);

            return Created("", jogador);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(repository.Listar());
        }

        [HttpPost("resultado")]
        public IActionResult RegistrarResultado(
            [FromBody] ResultadoPeneira resultado)
        {
            Jogador jogador =
                repository.BuscarPorCpf(resultado.CPF);

            if (jogador == null)
            {
                return NotFound(
                    "Jogador não encontrado. O resultado não pode ser registrado.");
            }

            if (jogador.Aprovado != null)
            {
                return BadRequest(
                    "O resultado desse jogador já foi registrado.");
            }

            repository.RegistrarResultado(
                resultado.CPF,
                resultado.Aprovado);

            return Ok("Resultado registrado com sucesso.");
        }

        [HttpGet("aprovados")]
        public IActionResult ListarAprovados()
        {
            return Ok(repository.ListarAprovados());
        }
    }
}