using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PesquisaEleitoral_MVC.Models
{
    public class Apuracao
    {
        Candidato Candidato { get; set; }

        List<Eleitor> Eleitores { get; set; }

    }
}