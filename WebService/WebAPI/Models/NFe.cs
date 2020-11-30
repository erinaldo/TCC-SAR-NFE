using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class NFe
    {
        public int CHNFE { get; set; }
        public int nNF { get; set; }
        public int Dest_CNPJ { get; set; }
        public string Dest_xNome { get; set; }
        public string Dest_xLgr { get; set; }
        public string Dest_xBairro { get; set; }
        public string Dest_xMun { get; set; }
        public string Dest_UF { get; set; }
        public int Dest_CEP { get; set; }
        public int Dest_fone { get; set; }
        public int Dest_IE { get; set; }
        public string dEmit { get; set; }
        public string dRecbto { get; set; }
        public string hRecbto { get; set; }
        public int CNPJ { get; set; }
        public string Emit_xNome { get; set; }
        public string Emit_xLgr { get; set; }
        public string Emit_xBairro { get; set; }
        public string Emit_xMun { get; set; }
        public string Emit_UF { get; set; }
        public int Emit_CEP { get; set; }
        public int Emit_fone { get; set; }
        public int Emit_IE { get; set; }
        public int Emit_nro { get; set; }
        public int vBc { get; set; }
        public int vICMS { get; set; }
        public int vBCTS { get; set; }
        public int vProd { get; set; }
        public int vFrete { get; set; }
        public int vSeg { get; set; }
        public int vDesc { get; set; }
        public int vIPI { get; set; }
        public int vOutro { get; set; }
        public int vNF { get; set; }
        public int Transp_CNPJ { get; set; }
        public string Transp_xNome { get; set; }
        public string Transp_xLgr { get; set; }
        public string Transp_xMun { get; set; }
        public string Transp_UF { get; set; }
        public int Transp_IE { get; set; }
        public int qVol { get; set; }
        public string esp { get; set; }
        public string error { get; set; }
        public int modfrete { get; set; }
        public int nProt { get; set; }
        public string natOp { get; set; }
    }
}