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
        private static ApplicationDbContext ctx;

        public BairroDAO()
        {
            ctx = new ApplicationDbContext();
        }


       public static bool AdicionarBairro(Bairro b)
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

        public static Bairro VerificarBairroPorNome(Bairro b)
        {
            return ctx.Bairros.FirstOrDefault(x => x.Nome.Equals(b.Nome));
        }

        public static Bairro VerificarBairroPorId(Bairro b)
        {
            return ctx.Bairros.FirstOrDefault(x => x.Id == b.Id);
        }

        public static List<Bairro> RetornarLista()
        {
            ctx = new ApplicationDbContext();
            return ctx.Bairros.ToList();
        }
    }
}