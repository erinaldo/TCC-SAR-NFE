using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class res
    {
        public string CNPJ { get; set; }
        public string xNome { get; set; }
        public string xLgr { get; set; }
        public string xBairro { get; set; }
        public string xMun { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string fone { get; set; }
        public string IE { get; set; }
        public string dEmit { get; set; }
        public string dRecbto { get; set; }
        public string hRecbto { get; set; }

        public string erro { get; set; }

        public res(string CNPJ, string xNome, string xLgr, string xBairro, string xMun, string UF, string CEP, string fone, string IE, string dEmit, string dRecbto, string hRecbto, string erro)
        {
            this.CNPJ = CNPJ;
            this.xNome = xNome;
            this.xLgr = xLgr;
            this.xBairro = xBairro;
            this.xMun = xMun;
            this.UF = UF;
            this.CEP = CEP;
            this.fone = fone;
            this.IE = IE;
            this.dEmit = dEmit;
            this.dRecbto = dRecbto;
            this.hRecbto = hRecbto;
            this.erro = erro;
        }
    }
    public class DestinatarioController : ApiController
    {
        // GET: api/Destinatario
        public IEnumerable<string> Get(int id)
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Destinatario/5
        public List<res> Get()
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand querry = conn.CreateCommand();

            querry.CommandText = "SELECT CNPJ, xNome, xLgr, xBairro, xMun, UF, CEP, fone, IE, dEmit, dRecbto, hRecbto FROM destinatario";

            var res = new List<res>();
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
                res.Add(new res(fetch_query["CNPJ"].ToString(), fetch_query["xNome"].ToString(), fetch_query["xLgr"].ToString(), fetch_query["xBairro"].ToString(), fetch_query["xMun"].ToString(), fetch_query["UF"].ToString(), fetch_query["CEP"].ToString(), fetch_query["fone"].ToString(), fetch_query["IE"].ToString(), fetch_query["dEmit"].ToString(), fetch_query["dRecbto"].ToString(), fetch_query["hRecbto"].ToString(), null));
            }

            return res;
            //return new Emit().GetAll();

            
        }

        // POST: api/Destinatario
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Destinatario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Destinatario/5
        public void Delete(int id)
        {
        }
    }
}
