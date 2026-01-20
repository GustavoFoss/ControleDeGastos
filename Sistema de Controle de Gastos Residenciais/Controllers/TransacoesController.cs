using Microsoft.AspNetCore.Mvc;
using Sistema_de_Controle_de_Gastos_Residenciais.Application.Services;

namespace Sistema_de_Controle_de_Gastos_Residenciais.Controllers
{
    [ApiController]
    [Route("api/transacoes")]
    public class TransacoesController : ControllerBase
    {
        private readonly TransacaoService _service;

        public TransacoesController(TransacaoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Application.DTOs.TransacaoDto dto)
        {
            _service.Criar(dto.Descricao, dto.Valor, dto.Tipo, dto.PessoaId, dto.CategoriaId);
            return Ok();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_service.Listar());
        }
    }
}
