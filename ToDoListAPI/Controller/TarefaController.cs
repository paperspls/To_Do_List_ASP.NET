using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Model;
using Microsoft.AspNetCore.Authorization;
using ToDoListAPI.Service;

namespace ToDoListAPI.Controller
{
    [Authorize]
    [Route("~/tarefas")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        private readonly IValidator<Tarefa> _tarefaValidator;

        public TarefaController(
            ITarefaService tarefaService,
            IValidator<Tarefa> tarefaValidator
            )
        {
            _tarefaService = tarefaService;
            _tarefaValidator = tarefaValidator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _tarefaService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _tarefaService.GetById(id);

            if (Resposta is null) 
            {
                return NotFound();
            }

            return Ok(Resposta);
        }

        [HttpGet("texto/{texto}")]
        public async Task<ActionResult> GetByTexto(string texto)
        {
            return Ok(await _tarefaService.GetByTexto(texto));
        }

        [HttpGet("urgencia/{urgencia}")]
        public async Task<ActionResult> GetByUrgencia(string urgencia)
        {
            return Ok(await _tarefaService.GetByUrgencia(urgencia));
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult> GetByStatus(string status)
        {
            return Ok(await _tarefaService.GetByStatus(status));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Tarefa tarefa)
        {
            var validarTarefa = await _tarefaValidator.ValidateAsync(tarefa);

            if (!validarTarefa.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarTarefa);

            var Resposta =await _tarefaService.Create(tarefa);

            if (Resposta is null)
                return BadRequest("Categoria não encontrada!");

            return CreatedAtAction(nameof(GetById), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Tarefa tarefa)
        {
            if (tarefa.Id == 0)
                return BadRequest("Id da Tarefa é inválido!");

            var validarTarefa = await _tarefaValidator.ValidateAsync(tarefa);

            if (!validarTarefa.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarTarefa);
            
            var Resposta = await _tarefaService.Update(tarefa);

            if (Resposta is null)
                return NotFound("Tarefa e/ou Categoria não encontrada!");

            return Ok(Resposta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var BuscaTarefa = await _tarefaService.GetById(id);

            if (BuscaTarefa is null)
                return NotFound("Postagem não encontrada!");

            await _tarefaService.Delete(BuscaTarefa);

            return Ok("Tarefa apagada com sucesso!");
        }
    }
}
