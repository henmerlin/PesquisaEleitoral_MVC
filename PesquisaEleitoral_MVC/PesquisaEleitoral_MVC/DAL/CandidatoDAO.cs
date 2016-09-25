using PesquisaEleitoral_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PesquisaEleitoral_MVC.DAL
{
    public class CandidatoDAO
    {
        private ApplicationDbContext ctx;

        public CandidatoDAO()
        {
            ctx = new ApplicationDbContext();
        }


        public bool AdicionarCandidato(Models.Candidato c)
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

        public Candidato VerificarCandidatoPorNome(Candidato c)
        {
            return ctx.Candidatos.FirstOrDefault(x => x.Nome.Equals(c.Nome));
        }

        public Candidato VerificarCandidatoPorNumero(Candidato c)
        {
            return ctx.Candidatos.FirstOrDefault(x => x.Numero == c.Numero);
        }

        public List<Candidato> RetornarLista()
        {
            return ctx.Candidatos.ToList();
        }
    }
}