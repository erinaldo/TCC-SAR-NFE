using LeitorNfe.Outros;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class result_T
    {
        public string CNPJ { get; set; }
        public string xNome { get; set; }
        public string IE { get; set; }
        public string xEnder { get; set; }
        public string xMun { get; set; }
        public string UF { get; set; }
        public string qVol { get; set; }
        public string esp { get; set; }

        public string error { get; set; }

        public result_T(string CNPJ, string xNome, string IE, string xEnder, string xMun, string UF, string qVol, string esp, string error)
        {
            this.CNPJ = CNPJ;
            this.xNome = xNome;
            this.IE = IE;
            this.xEnder = xEnder;
            this.xMun = xMun;
            this.UF = UF;
            this.qVol = qVol;
            this.esp = esp;
            
            this.error = error;
        }
    }


    public class TransportadorController : ApiController
    {
        // GET: api/Transportador
        public IEnumerable<string> Get(int id)
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Transportador/5
         public List<result_T> Get()
         {
                MySqlConnection conn = WebApiConfig.conn();
                MySqlCommand querry = conn.CreateCommand();

                querry.CommandText = "SELECT CNPJ, xNome, IE, xEnder, xMun, UF, qVol, esp FROM transportador";

                var result_T = new List<result_T>();
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
                    result_T.Add(new result_T(fetch_query["CNPJ"].ToString(), fetch_query["xNome"].ToString(), fetch_query["IE"].ToString(), fetch_query["xEnder"].ToString(), fetch_query["xMun"].ToString(), fetch_query["UF"].ToString(), fetch_query["qVol"].ToString(), fetch_query["esp"].ToString(), null));
                }

                return result_T;
                
          }

        // POST: api/Trasportador
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Trasportador/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Trasportador/5
        public void Delete(int id)
        {
        }
    }
}
