using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PesquisaEleitoral_MVC.Models;
using PesquisaEleitoral_MVC.Utils;
using PesquisaEleitoral_MVC.DAL;

namespace PesquisaEleitoral_MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CandidatoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Candidato/
        public ActionResult Index()
        {
            return View(db.Candidatos.ToList());
        }

        // GET: /Candidato/Erro
        public ActionResult Erro()
        {
            return View();
        }

        // GET: /Candidato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidatos.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        // GET: /Candidato/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: /Candidato/ErroExistente
        public ActionResult ErroExistente()
        {
            return View();
        }

        // POST: /Candidato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Numero")] Candidato candidato)
        {
            CandidatoDAO dao = new CandidatoDAO();

            if (ModelState.IsValid)
            {
                string nome = candidato.Nome;
                nome = StringUtil.TratativaProva(nome);
                candidato.Nome = nome;

                Candidato c1 = dao.VerificarCandidatoPorNome(candidato);
                Candidato c2 = dao.VerificarCandidatoPorNumero(candidato);

                if(c1 == null && c2 == null)
                {
                    db.Candidatos.Add(candidato);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("ErroExistente");
                }
            }
            return View(candidato);
        }

        // GET: /Candidato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidatos.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        // POST: /Candidato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Numero")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                string nome = candidato.Nome;
                nome = StringUtil.TratativaProva(nome);
                candidato.Nome = nome;

                db.Entry(candidato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidato);
        }

        // GET: /Candidato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidatos.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        // POST: /Candidato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Candidato candidato = db.Candidatos.Find(id);
                db.Candidatos.Remove(candidato);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("Erro");
            }
           
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
