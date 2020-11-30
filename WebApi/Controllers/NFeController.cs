using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class result_NFe
    {
        public string nNF { get; set; }
        public string Dest_CNPJ { get; set; }
        public string Dest_xNome { get; set; }
        public string Dest_xLgr { get; set; }
        public string Dest_xBairro { get; set; }
        public string Dest_xMun { get; set; }
        public string Dest_UF { get; set; }
        public string Dest_CEP { get; set; }
        public string Dest_fone { get; set; }
        public string Dest_IE { get; set; }
        public string dEmit { get; set; }
        public string dRecbto { get; set; }
        public string hRecbto { get; set; }
        public string CNPJ { get; set; }
        public string Emit_xNome { get; set; }
        public string Emit_xLgr { get; set; }
        public string Emit_xBairro { get; set; }
        public string Emit_xMun { get; set; }
        public string Emit_UF { get; set; }
        public string Emit_CEP { get; set; }
        public string Emit_fone { get; set; }
        public string Emit_IE { get; set; }
        public string Emit_nro { get; set; }
        public string vBc { get; set; }
        public string vICMS { get; set; }
        public string vBCTS { get; set; }
        public string vProd { get; set; }
        public string vFrete { get; set; }
        public string vSeg { get; set; }
        public string vDesc { get; set; }
        public string vIPI { get; set; }
        public string vOutro { get; set; }
        public string vNF { get; set; }
        public string Transp_CNPJ { get; set; }
        public string Transp_xNome { get; set; }
        public string Transp_xLgr { get; set; }
        public string Transp_xMun { get; set; }
        public string Transp_UF { get; set; }
        public string Transp_IE { get; set; }
        public string qVol { get; set; }
        public string esp { get; set; }
        public string error { get; set; }

        public result_NFe(string nNF, string Dest_CNPJ, string Dest_xNome, string Dest_xLgr, string Dest_xBairro, string Dest_xMun, string Dest_UF, string Dest_CEP, string Dest_fone, string Dest_IE, string dEmit, string dRecbto, string hRecbto, string CNPJ, string Emit_xNome, string Emit_xLgr, string Emit_xBairro, string Emit_xMun, string Emit_UF, string Emit_CEP, string Emit_fone, string Emit_IE, string Emit_nro, string vBc, string vICMS, string vBCTS, string vProd, string vFrete, string vSeg, string vDesc, string vIPI, string vOutro, string vNF, string Transp_CNPJ, string Transp_xNome, string Transp_xLgr, string Transp_xMun, string Transp_UF, string Transp_IE, string qVol, string esp, string error)
        {
            this.nNF = nNF;
            this.Dest_CNPJ = Dest_CNPJ;
            this.Dest_xNome = Dest_xNome;
            this.Dest_xLgr = Dest_xLgr;
            this.Dest_xBairro = Dest_xBairro;
            this.Dest_xMun = Dest_xMun;
            this.Dest_UF = Dest_UF;
            this.Dest_CEP = Dest_CEP;
            this.Dest_fone = Dest_fone;
            this.Dest_IE = Dest_IE;
            this.dEmit = dEmit;
            this.dRecbto = dRecbto;
            this.hRecbto = hRecbto;
            this.CNPJ = CNPJ;
            this.Emit_xNome = Emit_xNome;
            this.Emit_xLgr = Emit_xLgr;
            this.Emit_xBairro = Emit_xBairro;
            this.Emit_xMun = Emit_xMun;
            this.Emit_UF = Emit_UF;
            this.Emit_CEP = Emit_CEP;
            this.Emit_fone = Emit_fone;
            this.Emit_IE = Emit_IE;
            this.Emit_nro = Emit_nro;
            this.vBc = vBc;
            this.vICMS = vICMS;
            this.vBCTS = vBCTS;
            this.vProd = vProd;
            this.vFrete = vFrete;
            this.vSeg = vSeg;
            this.vDesc = vDesc;
            this.vIPI = vIPI;
            this.vOutro = vOutro;
            this.vNF = vNF;
            this.Transp_CNPJ = Transp_CNPJ;
            this.Transp_xNome = Transp_xNome;
            this.Transp_xLgr = Transp_xLgr;
            this.Transp_xMun = Transp_xMun;
            this.Transp_UF = Transp_UF;
            this.Transp_IE = Transp_IE;
            this.qVol = qVol;
            this.esp = esp;
            this.error = error;
        }
    }

    public class NFeController : ApiController
    {
        // GET: api/NFe
        public IEnumerable<string> Get(int id)
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NFe/5
        public List<result_NFe> Get()
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand querry = conn.CreateCommand();

            querry.CommandText = "SELECT * FROM completa";

            var result_NFe = new List<result_NFe>();
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
                result_NFe.Add(new result_NFe(fetch_query["nNF"].ToString(), fetch_query["Dest_CNPJ"].ToString(), fetch_query["Dest_xNome"].ToString(), fetch_query["Dest_xLgr"].ToString(), fetch_query["Dest_xBairro"].ToString(), fetch_query["Dest_xMun"].ToString(), fetch_query["Dest_UF"].ToString(), fetch_query["Dest_CEP"].ToString(), fetch_query["Dest_fone"].ToString(), fetch_query["Dest_IE"].ToString(), fetch_query["dEmit"].ToString(), fetch_query["dRecbto"].ToString(), fetch_query["hRecbto"].ToString(), fetch_query["CNPJ"].ToString(), fetch_query["Emit_xNome"].ToString(), fetch_query["Emit_xLgr"].ToString(), fetch_query["Emit_xBairro"].ToString(), fetch_query["Emit_xMun"].ToString(), fetch_query["Emit_UF"].ToString(), fetch_query["Emit_CEP"].ToString(), fetch_query["Emit_fone"].ToString(), fetch_query["Emit_IE"].ToString(), fetch_query["Emit_nro"].ToString(), fetch_query["vBc"].ToString(), fetch_query["vICMS"].ToString(), fetch_query["vBCTS"].ToString(), fetch_query["vProd"].ToString(), fetch_query["vFrete"].ToString(), fetch_query["vSeg"].ToString(), fetch_query["vDesc"].ToString(), fetch_query["vIPI"].ToString(), fetch_query["vOutro"].ToString(), fetch_query["vNF"].ToString(), fetch_query["Transp_CNPJ"].ToString(), fetch_query["Transp_xNome"].ToString(), fetch_query["Transp_xLgr"].ToString(), fetch_query["Transp_xMun"].ToString(), fetch_query["Transp_UF"].ToString(), fetch_query["Transp_IE"].ToString(), fetch_query["qVol"].ToString(), fetch_query["esp"].ToString(), null));
            }

            return result_NFe;
            //return new Emit().GetAll();


        }

        // POST: api/NFe
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/NFe/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/NFe/5
        public void Delete(int id)
        {
        }
    }
}
