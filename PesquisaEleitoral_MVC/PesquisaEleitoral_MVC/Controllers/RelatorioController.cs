using PesquisaEleitoral_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PesquisaEleitoral_MVC.Controllers
{
    [Authorize]
    public class RelatorioController : Controller
    {
        // GET: Relatorio
        public ActionResult Index()
        {
            RelatorioViewModel m = new RelatorioViewModel();

            ViewBag.Data = m.Relatorio();

            return View(m);
        }


        public ActionResult FaixaEtaria()
        {
            RelatorioViewModel m = new RelatorioViewModel();

            ViewBag.Data = m.RelatorioFaixaEtaria();

            return View(m);
        }
    }





    
}