using LeitorNfe.Outros;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class results
    {
        public string cnpj { get; set; }
        public string xnome { get; set; }
        public string xlgr { get; set; }
        public string nro { get; set; }
        public string xBairro { get; set; }
        public string xMun { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Fone { get; set; }
        public string IE { get; set; }
        public string error { get; set; }


        public results(string cnpj, string xnome, string xlgr, string nro, string xBairro, string xMun, string UF, string CEP, string Fone, string IE,  string error)
        {
            this.cnpj = cnpj;
            this.xnome = xnome;
            this.xlgr = xlgr;
            this.nro = nro;
            this.xBairro = xBairro;
            this.xMun = xMun;
            this.UF = UF;
            this.CEP = CEP;
            this.Fone = Fone;
            this.IE = IE;
            this.error = error;
        }
    }

    public class EmitsController : ApiController
    {
        
        // GET: api/Emits
        public IEnumerable<string> Get(int id)
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Emits/5
        public List<results> Get()
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand querry = conn.CreateCommand();

            querry.CommandText = "SELECT CNPJ, xNome, xLgr, nro, xBairro, xMun, UF, CEP, fone, IE FROM emitente";

            var results = new List<results>();
            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw;
            }

            MySqlDataReader fetch_query = querry.ExecuteReader();

            while (fetch_query.Read())
            {
                results.Add(new results(fetch_query["CNPJ"].ToString(), fetch_query["xNome"].ToString(), fetch_query["xLgr"].ToString(), fetch_query["nro"].ToString(), fetch_query["xBairro"].ToString(), fetch_query["xMun"].ToString(), fetch_query["UF"].ToString(), fetch_query["CEP"].ToString(), fetch_query["fone"].ToString(), fetch_query["IE"].ToString(), null ));
            }
            
            return results;
            //return new Emit().GetAll();
        }

        // POST: api/Emits
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Emits/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Emits/5
        public void Delete(int id)
        {
        }
    }
}
