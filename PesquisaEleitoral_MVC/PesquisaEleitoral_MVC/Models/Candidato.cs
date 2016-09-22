using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PesquisaEleitoral_MVC.Models
{
    [Table("Candidato")]
    public class Candidato
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Nome { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [Range(10, 99, ErrorMessage = "Digite um número válido")]
        public int Numero { get; set; }

    }
}