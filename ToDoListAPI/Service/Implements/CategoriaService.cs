using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data;
using ToDoListAPI.Model;

namespace ToDoListAPI.Service.Implements
{
    public class CategoriaService : ICategoriaService
    {
        public readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categorias
                 .Include(c => c.Tarefa)
                 .ToListAsync();
        }

        public async Task<Categoria?> GetById(long id)
        {
            try
            {
                var Categoria = await _context.Categorias
                     .Include(c => c.Tarefa)
                     .FirstAsync(c => c.Id == id);

                return Categoria;
            }
            catch
            {
                return null;
            }

        }

        public async Task<IEnumerable<Categoria>> GetByNome(string nome)
        {
            var Categoria = await _context.Categorias
               
                .Where(c => c.Nome.Contains(nome))
                .Include(c => c.Tarefa)
                .ToListAsync();

            return Categoria;
        }

        public async Task<Categoria> Create(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task<Categoria?> Update(Categoria categoria)
        {

            var CategoriaUpdate = await _context.Categorias.FindAsync(categoria.Id);

            if (CategoriaUpdate is null)
                return null;

            _context.Entry(CategoriaUpdate).State = EntityState.Detached;
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task Delete(Categoria categoria)
        {

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

        }

    }
}
