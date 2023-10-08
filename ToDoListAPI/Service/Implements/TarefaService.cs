using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data;
using ToDoListAPI.Model;

namespace ToDoListAPI.Service.Implements
{
    public class TarefaService : ITarefaService
    {
        private readonly AppDbContext _context;

        public TarefaService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> GetAll()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<Tarefa?> GetById(long id)
        {
            try
            {
                var Tarefa = await _context.Tarefas.FirstAsync(t => t.Id == id);

                return Tarefa;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Tarefa>> GetByStatus(string status)
        {
            var Tarefa = await _context.Tarefas
                .Where(t => t.Status.Contains(status))
                .ToListAsync();

            return Tarefa;
        }

        public async Task<IEnumerable<Tarefa>> GetByTexto(string texto)
        {
            var Tarefa = await _context.Tarefas
                .Where(t => t.Texto.Contains(texto))
                .ToListAsync();

            return Tarefa;
        }

        public async Task<IEnumerable<Tarefa>> GetByUrgencia(string urgencia)
        {
            var Tarefa = await _context.Tarefas
               .Where(t => t.Urgencia.Contains(urgencia))
               .ToListAsync();

            return Tarefa;
        }

        public async Task<Tarefa?> Create(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();

            return tarefa;
        }

        public async Task<Tarefa?> Update(Tarefa tarefa)
        {
            var TarefaUpdate = await _context.Tarefas.FindAsync(tarefa.Id);

            if (TarefaUpdate is null)
                return null;

            _context.Entry(TarefaUpdate).State = EntityState.Detached;
            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return tarefa;
        }

        public async Task Delete(Tarefa tarefa)
        {
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
        }

    }
}
