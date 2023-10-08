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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tarefa>> GetByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tarefa>> GetByTexto(string texto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tarefa>> GetByUrgencia(string urgencia)
        {
            throw new NotImplementedException();
        }

        public async Task<Tarefa?> Create(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public async Task<Tarefa?> Update(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

    }
}
