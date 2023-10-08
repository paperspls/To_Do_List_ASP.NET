using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListAPI.Model
{
    public class Categoria
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Titulo { get; set; } = string.Empty;

    }
}