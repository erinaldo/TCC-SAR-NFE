using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class result_I
    {
        public string nNF { get; set; }
        public string vBC { get; set; }
        public string vICMS { get; set; }
        public string vBCST { get; set; }
        public string vProd { get; set; }
        public string vFrete { get; set; }
        public string vSeg { get; set; }
        public string vDesc { get; set; }
        public string vIPI { get; set; }
        public string vOutro { get; set; }
        public string vNF { get; set; }

        public string error { get; set;}
        
        public result_I(string nNF, string vBC, string vICMS, string vBCST, string vProd, string vFrete, string vSeg, string vDesc, string vIPI, string vOutro, string vNF, string error)
        {
            this.nNF = nNF;
            this.vBC = vBC;
            this.vICMS = vICMS;
            this.vBCST = vBCST;
            this.vProd = vProd;
            this.vFrete = vFrete;
            this.vSeg = vSeg;
            this.vDesc = vDesc;
            this.vIPI = vIPI;
            this.vOutro = vOutro;
            this.vNF = vNF;

            this.error = error;
        }
    }

    public class ImpostoController : ApiController
    {
        // GET: api/Imposto
        public IEnumerable<string> Get(int id)
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Imposto/5
        public List<result_I> Get()
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand querry = conn.CreateCommand();

            querry.CommandText = "SELECT nNF, vBC, vICMS, vBCST, vProd, vFrete, vSeg, vDesc, vIPI, vOutro, vNF FROM imposto";

            var result_I = new List<result_I>();
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
                result_I.Add(new result_I(fetch_query["nNF"].ToString(), fetch_query["vBC"].ToString(), fetch_query["vICMS"].ToString(), fetch_query["vBCST"].ToString(), fetch_query["vProd"].ToString(), fetch_query["vFrete"].ToString(), fetch_query["vSeg"].ToString(), fetch_query["vDesc"].ToString(), fetch_query["vIPI"].ToString(), fetch_query["vOutro"].ToString(), fetch_query["vNF"].ToString(), null));
            }

            return result_I;

        }
        // POST: api/Imposto
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Imposto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Imposto/5
        public void Delete(int id)
        {
        }
    }
}
