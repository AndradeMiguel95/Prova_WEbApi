using Prova_WEbApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prova_WEbApi.Controllers
{
    public class PessoaController : ApiController
    {
        // GET: api/Pessoa
        public IEnumerable<Pessoas> Get()
        {
            Pessoas pessoa = new Pessoas();
            return pessoa.ListaPessoas();
        }

        // GET: api/Pessoa/5
        public Pessoas Get(int id)
        {
            Pessoas pessoa = new Pessoas();
            return pessoa.ListaPessoas().Where(x=>x.Mid == id).FirstOrDefault();
        }

        // POST: api/Pessoa
        public List<Pessoas> Post(Pessoas pessoa)
        {
            Pessoas _pessoa = new Pessoas();
            _pessoa.Inserir(pessoa);
            return _pessoa.ListaPessoas();
        }

        // PUT: api/Pessoa/5
        public List<Pessoas> Put(int id, Pessoas pessoa)
        {
            Pessoas _pessoa = new Pessoas();
            _pessoa.Atualizar(id, pessoa);
            return _pessoa.ListaPessoas();

        }

        // DELETE: api/Pessoa/5
        public void Delete(int id)
        {
            Pessoas _pessoa = new Pessoas();
            _pessoa.Deletar(id);


        }
    }
}
