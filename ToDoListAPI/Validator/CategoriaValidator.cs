using FluentValidation;
using ToDoListAPI.Model;

namespace ToDoListAPI.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {

        public CategoriaValidator()
        {
            RuleFor(c => c.Titulo)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);
        }
    }
}