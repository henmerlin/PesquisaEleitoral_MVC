using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PesquisaEleitoral_MVC.Models
{
    public class CandidatoRelatorio
    {

        public string Nome { get; set; }

        public int Numero { get; set; }

        public List<Eleitor> Eleitores { get; set; }

    }
}