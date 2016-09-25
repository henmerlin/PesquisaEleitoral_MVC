using PesquisaEleitoral.Models;
using PesquisaEleitoral_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PesquisaEleitoral_MVC.DAL
{
    public class BairroDAO
    {
        private ApplicationDbContext ctx;

        public BairroDAO()
        {
            ctx = new ApplicationDbContext();
        }

       public bool AdicionarBairro(Bairro b)
        {
            try
            {
                ctx.Bairros.Add(b);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Bairro VerificarBairroPorNome(Bairro b)
        {
            return ctx.Bairros.FirstOrDefault(x => x.Nome.Equals(b.Nome));
        }

        public Bairro VerificarBairroPorId(Bairro b)
        {
            return ctx.Bairros.FirstOrDefault(x => x.Id == b.Id);
        }

        public List<Bairro> RetornarLista()
        {
            return ctx.Bairros.ToList();
        }
    }
}