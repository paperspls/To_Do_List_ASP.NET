using ToDoListAPI.Model;

namespace ToDoListAPI.Service.Implements
{
    public class TarefaService : ITarefaService
    {
        public Task<IEnumerable<Tarefa>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Tarefa?> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tarefa>> GetByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tarefa>> GetByTexto(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tarefa>> GetByUrgencia(string urgencia)
        {
            throw new NotImplementedException();
        }

        public Task<Tarefa?> Create(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public Task<Tarefa?> Update(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

    }
}
