using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class result_P
    {

        public string cProd { get; set; }
        public string nNF { get; set; }
        public string xProd { get; set; }
        public string NCM { get; set; }
        public string CFOP { get; set; }
        public string uCom { get; set; }
        public string qCom { get; set; }
        public string vUnCom { get; set; }
        public string vProd { get; set; }

        public string error { get; set; }

        public result_P(string cProd, string nNF, string xProd, string NCM, string CFOP, string uCom, string qCom, string vUnCom, string vProd, string error )
        {
            this.cProd = cProd;
            this.nNF = nNF;
            this.xProd = xProd;
            this.NCM = NCM;
            this.CFOP = CFOP;
            this.uCom = uCom;
            this.qCom = qCom;
            this.vUnCom = vUnCom;
            this.vProd = vProd;
            this.error = error;
        }

    }
    public class ProdutosController : ApiController
    {
        // GET: api/Produtos
        public IEnumerable<string> Get(int id)
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Produtos/5
        public List<result_P> Get()
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand querry = conn.CreateCommand();

            querry.CommandText = "SELECT cProd, nNF, xProd, NCM, CFOP, uCom, qCom, vUnCom, vProd FROM produtos";

            var result_P = new List<result_P>();
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
                result_P.Add(new result_P(fetch_query["cProd"].ToString(), fetch_query["nNF"].ToString(), fetch_query["xProd"].ToString(), fetch_query["NCM"].ToString(), fetch_query["CFOP"].ToString(), fetch_query["uCom"].ToString(), fetch_query["qCom"].ToString(), fetch_query["vUnCom"].ToString(), fetch_query["vProd"].ToString(), null));
            }

            return result_P;

        }
        // POST: api/Produtos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Produtos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Produtos/5
        public void Delete(int id)
        {
        }
    }
}
