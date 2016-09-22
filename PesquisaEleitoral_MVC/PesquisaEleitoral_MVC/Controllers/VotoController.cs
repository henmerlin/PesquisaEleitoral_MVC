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

        //
        // POST: /Voto/Index
        [HttpPost]
        public ActionResult Index(VotoViewModel model)
        {
            try
            {
                ApplicationUser u = new ApplicationUser();
                u.UserName = System.Web.HttpContext.Current.User.Identity.Name;
                u = UsuarioDAO.VerificarCandidatoPorNome(u);
                
                Candidato c = new Candidato();
                c.Numero = model.NumeroCandidato;
                c = CandidatoDAO.VerificarCandidatoPorNumero(c);
                u.VotoId = c.Id;

                UsuarioDAO.AlterarUsuario(u);

                ModelState.AddModelError("", "Invalid username or password.");

                return View(model);
            }
            catch
            {
                return View();
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
