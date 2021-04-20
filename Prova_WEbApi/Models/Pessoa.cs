using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Prova_WEbApi.Models
{
    public class Pessoas
    {
        public int Mid { get; set; }

        public string Mnome { get; set; }

        public string Mcpf { get; set; }

        public string Mtelefone { get; set; }

        public string Memail { get; set; }

        public int Midade { get; set; }

        public List<Pessoas> ListaPessoas()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\Base.json");
            var json = File.ReadAllText(caminhoArquivo);
            var ListaPessoas = JsonConvert.DeserializeObject<List<Pessoas>>(json);

            return ListaPessoas;
        }
        public bool ReescreverArquivo(List<Pessoas> listaPessoas)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\base.json");
            var json = JsonConvert.SerializeObject(listaPessoas, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);
            return true;
        }

        public Pessoas Inserir(Pessoas Pessoa)
        {
            var ListaPessoas = this.ListaPessoas();
            var maxId = ListaPessoas.Max(pessoa => pessoa.Mid);
            Pessoa.Mid = maxId + 1;
            ListaPessoas.Add(Pessoa);
            ReescreverArquivo(ListaPessoas);
            return Pessoa;
        }

        public Pessoas Atualizar(int Mid, Pessoas Pessoa)
        {
            var ListaPessoas = this.ListaPessoas();
            var itemIndex = ListaPessoas.FindIndex(p => p.Mid == Mid);
            if (itemIndex >= 0)
            {
                Pessoa.Mid = Mid;
                ListaPessoas[itemIndex] = Pessoa;

            }
            else
            {
                return null;
            }
            ReescreverArquivo(ListaPessoas);
            return Pessoa;
        }

        public bool Deletar(int id)
        {
            var ListaPessoas = this.ListaPessoas();
            var itemIndex = ListaPessoas.FindIndex(p => p.Mid == id);
            if (itemIndex >= 0)
            {
                ListaPessoas.RemoveAt(itemIndex);

            }
            else
            {
                return false;
            }
            ReescreverArquivo(ListaPessoas);
            return true;
        }
    }
}