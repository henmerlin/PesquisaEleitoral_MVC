using PesquisaEleitoral_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PesquisaEleitoral_MVC.DAL
{
    public class UsuarioDAO
    {
        private ApplicationDbContext ctx;

        public UsuarioDAO(){
            ctx = new ApplicationDbContext();
        }

        public bool AlterarUsuario(ApplicationUser u)
        {
            try
            {
                ctx.Entry(u).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public ApplicationUser VerificarUsuarioPorNome(ApplicationUser u)
        {
            return ctx.Users.FirstOrDefault(x => x.UserName.Equals(u.UserName));
        }


    }
}