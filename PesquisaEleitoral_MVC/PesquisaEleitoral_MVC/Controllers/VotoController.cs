using PesquisaEleitoral_MVC.DAL;
using PesquisaEleitoral_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PesquisaEleitoral_MVC.Controllers
{
    [Authorize]
    public class VotoController : Controller
    {
        //
        // GET: /Voto/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Voto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Voto/Create
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Sucesso()
        {
            return View();
        }

        public ActionResult Erro()
        {
            return View();
        }

        public ActionResult NaoEncontrado()
        {
            return View();
        }

 

        //
        // POST: /Voto/Index
        [HttpPost]
        public ActionResult Index(VotoViewModel model)
        {
            ApplicationUser u = new ApplicationUser();
            Candidato c = new Candidato();

            try
            {
                
                u.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                u = UsuarioDAO.VerificarUsuarioPorNome(u);
                c.Numero = model.NumeroCandidato;
                c = CandidatoDAO.VerificarCandidatoPorNumero(c);

                if (c == null)
                {
                    return RedirectToAction("NaoEncontrado", "Voto");
                }

                u.VotoId = c.Id;

                UsuarioDAO.AlterarUsuario(u);

                return RedirectToAction("Sucesso", "Voto");

            }
            catch
            {
                ModelState.AddModelError("", "Invalid username or password.");

                return RedirectToAction("Erro", "Voto");
            }
        }

        //
        // GET: /Voto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Voto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Voto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Voto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
