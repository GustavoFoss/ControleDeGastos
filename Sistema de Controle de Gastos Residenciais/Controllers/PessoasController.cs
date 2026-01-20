using Microsoft.AspNetCore.Mvc;
using SistemaDeControleDeGastosResidenciais.Application.Services;

namespace Sistema_de_Controle_de_Gastos_Residenciais.Controllers
{
    [ApiController]
    [Route("api/pessoas")]
    public class PessoasController : ControllerBase
    {
        private readonly PessoaService _service;

        public PessoasController(PessoaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Application.DTOs.PessoaDto dto)
        {
            _service.Criar(dto.Nome, dto.Idade);
            return Ok();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_service.Listar());
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(System.Guid id)
        {
            _service.Deletar(id);
            return NoContent();
        }
    }
}
