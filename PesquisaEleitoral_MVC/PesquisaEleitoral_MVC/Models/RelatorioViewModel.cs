using PesquisaEleitoral.Models;
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
            UsuarioDAO user = new UsuarioDAO();
            CandidatoDAO cand = new CandidatoDAO();


            sb.Append("[");
            sb.Append("['Candidato',");

            foreach (var cadtos in Candidatos)
            {
                sb.Append("\'"+ cadtos.Nome +"\',");
            }

            sb.Length--;
            sb.Append("],");

            List<string> lista = new List<string>();

            lista.Add("Menos de 20 anos");
            lista.Add("De 21 a 30 anos");
            lista.Add("De 31 a 50 anos");
            lista.Add("Mais de 50 anos");

            foreach (var fe in lista)
            {
                sb.Append("[\'" + fe + "', ");

                foreach (var c in Candidatos)
                {
                    int votos = c.Eleitores.FindAll(x => x.FaixaEtaria.Equals(fe)).Count;

                    sb.Append(votos);
                    sb.Append(",");
                }
                sb.Length--;
                sb.Append("],");
            }
            sb.Length--;
            sb.Append("]");

            return sb.ToString();
        }

        public string RelatorioBairros()
        {

            StringBuilder sb = new StringBuilder();
            UsuarioDAO user = new UsuarioDAO();
            CandidatoDAO cand = new CandidatoDAO();
            BairroDAO badao = new BairroDAO();


            sb.Append("[");
            sb.Append("['Candidato',");

            foreach (var cadtos in Candidatos)
            {
                sb.Append("\'" + cadtos.Nome + "\',");
            }

            sb.Length--;
            sb.Append("],");


            foreach (Bairro fe in badao.RetornarLista())
            {
                sb.Append("[\'" + fe.Nome + "', ");

                foreach (var c in Candidatos)
                {
                    int votos = c.Eleitores.FindAll(x => x.Bairro.Nome.Equals(fe.Nome)).Count;

                    sb.Append(votos);
                    sb.Append(",");
                }
                sb.Length--;
                sb.Append("],");
            }
            sb.Length--;
            sb.Append("]");

            return sb.ToString();
        }

    }
}