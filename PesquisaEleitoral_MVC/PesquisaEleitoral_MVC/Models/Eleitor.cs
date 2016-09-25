using PesquisaEleitoral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PesquisaEleitoral_MVC.Models
{
    public class Eleitor
    {

        public Bairro Bairro { get; set; }
        public string FaixaEtaria { get; set; }
        public int Idade { get; set; }

        public Eleitor()
        {

        }


        /**
         * o Menos de 20 anos;
            o De 21 a 30 anos;
            o De 31 a 50 anos;
            o Mais de 50 anos;
          */
        public void GeraFaixaEtaria(DateTime data)
        {
            int Ano = DateTime.Now.Year;
            int Idade = Ano - data.Year;
            this.Idade = Idade;

            if (Idade < 20)
            {
                FaixaEtaria = "Menos de 20 anos";
            } else if (Idade < 30)
            {
                FaixaEtaria = "De 21 a 30 anos";
            }
            else if(Idade < 50) {
                FaixaEtaria = "De 31 a 50 anos";
            } else{
                FaixaEtaria = "Mais de 50 anos";
            }
        }

    }
}
 