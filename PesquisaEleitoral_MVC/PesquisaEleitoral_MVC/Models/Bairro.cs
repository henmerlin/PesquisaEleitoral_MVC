using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PesquisaEleitoral.Models
{
    [Table("Bairros")]
    public class Bairro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

    }
}