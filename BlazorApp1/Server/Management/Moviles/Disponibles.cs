using BlazorApp1.Shared.Modelo.Moviles;
using BlazorApp1.Shared.User;
using BlazorApp1.Shared.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Management.Moviles
{
    public class Disponibles
    {

        public static async Task<IEnumerable<TipoMovil>> GetMovilesDisponibles(IUsuario usuario)
        {
            try
            {
                string Url = "selector_generico.do";
                Dictionary<string, string> Parameters = new Dictionary<string, string>();

                Parameters.Add("aaxmlrequest", "true");
                Parameters.Add("selector_campo", "");
                Parameters.Add("selector_tipo", "recogedores_repartidores");
                Parameters.Add("campos_visibles", "");
                //for (int i = 0; i < 10; i++)
                    Parameters.Add("selector_campo_filtro", "");
                //for (int i = 0; i < 10; i++)
                    Parameters.Add("selector_filtro", "");

                string body = await Shared.ClienteWeb.Consultas.ConsultaPost.PostAsync(Url, Parameters, usuario);


                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                List<TipoMovil> TipoMoviles = new List<TipoMovil>();

                document.LoadHtml(body);

                HtmlAgilityPack.HtmlNode TableBodyNode = Nodos.GetNode(document.DocumentNode, "tbody", "class", "cuerpo_tabla");

                HtmlAgilityPack.HtmlNodeCollection FilasTableNode = Nodos.GetNodes(TableBodyNode, "tr");

                foreach(var fila in FilasTableNode)
                {
                    HtmlAgilityPack.HtmlNodeCollection columnas = Nodos.GetNodes(fila, "td");
                    string codigo = columnas[0].InnerText;
                    string nombre = columnas[1].InnerText;
                    string tipo = columnas[2].InnerText;

                    TipoMoviles.Add(new TipoMovil(codigo,nombre,tipo));
                }

                return TipoMoviles;
            }
            catch
            {
                throw;
            }
        }
    }
}
