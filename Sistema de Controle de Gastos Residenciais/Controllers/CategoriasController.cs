using Microsoft.AspNetCore.Mvc;
using Sistema_de_Controle_de_Gastos_Residenciais.Application.Services;

namespace Sistema_de_Controle_de_Gastos_Residenciais.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaService _service;

        public CategoriasController(CategoriaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Application.DTOs.CategoriaDto dto)
        {
            _service.Criar(dto.Descricao, dto.Finalidade);
            return Ok();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_service.Listar());
        }
    }
}
