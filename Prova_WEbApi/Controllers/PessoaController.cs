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
        public IEnumerable<Pessoa> Get()
        {
            Pessoa pessoa = new Pessoa();
            return pessoa.listPessoa();
        }

        // GET: api/Pessoa/5
        public Pessoa Get(int id)
        {
            Pessoa pessoa = new Pessoa();
            return pessoa.listPessoa().Where(x=>x.Mid == id).FirstOrDefault();
        }

        // POST: api/Pessoa
        public void Post([FromBody]Pessoa pessoa)
        {

        }

        // PUT: api/Pessoa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pessoa/5
        public void Delete(int id)
        {
        }
    }
}
