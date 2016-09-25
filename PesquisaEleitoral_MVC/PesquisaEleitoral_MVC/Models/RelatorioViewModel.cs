using PesquisaEleitoral_MVC.DAL;
using System.Collections.Generic;
using System.Text;

namespace PesquisaEleitoral_MVC.Models
{
    public class RelatorioViewModel
    {
        public List<CandidatoRelatorio> Candidatos;

        public RelatorioViewModel()
        {
            UsuarioDAO user = new UsuarioDAO();
            CandidatoDAO cand = new CandidatoDAO();

            Candidatos = new List<CandidatoRelatorio>();

            foreach (var candidato in cand.RetornarLista())
            {
                CandidatoRelatorio cr = new CandidatoRelatorio();
                cr.Nome = candidato.Nome;
                cr.Numero = candidato.Numero;
                cr.Eleitores = new List<Eleitor>();

                foreach (ApplicationUser au in user.ListarVotosPorCandidato(candidato))
                {
                    Eleitor el = new Eleitor();
                    el.Bairro = au.Bairro;
                    el.GeraFaixaEtaria(au.DataNascimento);
                    cr.Eleitores.Add(el);
                }

                Candidatos.Add(cr);
            }
        }

        public string Relatorio()
        {

            StringBuilder sb = new StringBuilder();
            
            sb.Append("[");
            sb.Append("['Candidato', 'Votos'],");

            

            foreach (var item in Candidatos)
            {
                sb.Append("[\'" + item.Nome + "\'," + item.Eleitores.Count + "],");
            }
              
            sb.Append("]");

            return sb.ToString();
        }


        public string RelatorioFaixaEtaria()
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            sb.Append("['Candidato', 'Faixa Etária', 'Votos'],");

            foreach (var candidato in Candidatos)
            {
                foreach (var eleitor in candidato.Eleitores)
                {
                    sb.Append("[\'" + candidato.Nome + "\',"+  eleitor.Idade + "," + 1 + "],");
                }
            }

            sb.Append("]");

            return sb.ToString();
        }

    }
}