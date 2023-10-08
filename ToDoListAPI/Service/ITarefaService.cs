using ToDoListAPI.Model;

namespace ToDoListAPI.Service
{
    public interface ITarefaService
    {
        Task<IEnumerable<Tarefa>> GetAll();

        Task<Tarefa?> GetById(long id);

        Task<IEnumerable<Tarefa>> GetByTexto(string texto);

        Task<IEnumerable<Tarefa>> GetByUrgencia(string urgencia);

        Task<IEnumerable<Tarefa>> GetByStatus(string status);

        Task<Tarefa?> Create(Tarefa tarefa);

        Task<Tarefa?> Update(Tarefa tarefa);

        Task Delete(Tarefa tarefa);
    }
}
