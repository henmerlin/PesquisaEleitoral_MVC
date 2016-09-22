using PesquisaEleitoral_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PesquisaEleitoral_MVC.DAL
{
    public class CandidatoDAO
    {
        private static ApplicationDbContext ctx;

        public CandidatoDAO()
        {
            ctx = new ApplicationDbContext();
        }


        public static bool AdicionarCandidato(Models.Candidato c)
        {
            try
            {
                ctx.Candidatos.Add(c);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Candidato VerificarCandidatoPorNome(Candidato c)
        {
            return ctx.Candidatos.FirstOrDefault(x => x.Nome.Equals(c.Nome));
        }

        public static Candidato VerificarCandidatoPorNumero(Candidato c)
        {
            return ctx.Candidatos.FirstOrDefault(x => x.Numero == c.Numero);
        }

        public static List<Candidato> RetornarLista()
        {
            return ctx.Candidatos.ToList();
        }



    }
}