using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PesquisaEleitoral_MVC.Models
{
    public class VotoViewModel
    {
        [Required]
        [Display(Name = "Número do Candidato")]
        [Range(10, 99, ErrorMessage = "Digite um número válido")]
        public int NumeroCandidato { get; set; }

    }
}