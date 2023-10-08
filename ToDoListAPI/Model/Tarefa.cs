using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListAPI.Model
{
    public class Tarefa : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string Texto { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Urgencia { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Status { get; set; } = string.Empty;
    }
}
