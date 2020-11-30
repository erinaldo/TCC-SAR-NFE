using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class NFeRepositorio : IENFeRepositorio
    {
        private int _nextIEN = 1;

        private List<NFe> nfes = new List<NFe>();

        public NFeRepositorio()
        {
            Add(new NFe {CHNFE = 648577, nNF = 648577, Dest_CNPJ = 2147483647, Dest_xNome = "TECHNOSERVICE BRASIL MONTAGENS LTDA", Dest_xLgr = "AV. PIERRE SIMON DE LAPLACE", Dest_xBairro = "TECHNO PARK", Dest_xMun = "CAMPINAS", Dest_UF = "SP", Dest_CEP = 13069320, Dest_fone = 1937839730, Dest_IE = 2147483647, dEmit = "01/01/0001 00:00:00", dRecbto = "01/01/0001 00:00:00", hRecbto = "14:30:00", CNPJ = 2147483647, Emit_xNome = "SAMSUNG ELETRONICA DA AMAZONIA LTDA", Emit_xLgr = "Av. Thomas Nilsen Junior", Emit_xBairro = "Parque Imperador", Emit_xMun = "Campinas", Emit_UF = "SP", Emit_CEP = 13097105, Emit_fone = 1945012000, Emit_IE = 2147483647, Emit_nro = 150, vBc = 0, vICMS = 0, vBCTS = 0, vProd = 14101, vFrete = 0, vSeg = 0, vDesc = 0, vIPI = 0, vOutro = 0, vNF = 14101, Transp_CNPJ = 2147483647, Transp_xNome = "MOTO HELP ENTREGAS RAPIDAS LTDA EPP", Transp_xLgr = "RUA SERRA AZUL 277", Transp_xMun = "CAMPINAS", Transp_UF = "SP", Transp_IE = 2147483647, qVol = 1120, esp = "Peca", error = null });
            Add(new NFe { CHNFE = 648556, nNF = 648556, Dest_CNPJ = 336389320, Dest_xNome = "TECHNOSERVICE BRASIL MONTAGENS LTDA", Dest_xLgr = "AV. PIERRE SIMON DE LAPLACE", Dest_xBairro = "TECHNO PARK", Dest_xMun = "CAMPINAS", Dest_UF = "SP", Dest_CEP = 13069320, Dest_fone = 19378397, Dest_IE = 122143366, dEmit = "15/05/2020 12:20:07", dRecbto = "15/05/2020 ", hRecbto = "12=26=21", CNPJ = 00280273000, Emit_xNome = "SAMSUNG ELETRONICA DA AMAZONIA LTDA", Emit_xLgr = "Av. Thomas Nilsen Junior", Emit_xBairro = "Parque Imperador", Emit_xMun = "Campinas", Emit_UF = "SP", Emit_CEP = 13097105, Emit_fone = 1945012000, Emit_IE = 244956031, Emit_nro = 150, vBc = 0, vICMS = 40, vBCTS = 0, vProd = 26293, vFrete = 0, vSeg = 0, vDesc = 0, vIPI = 0, vOutro = 0, vNF = 26293, Transp_CNPJ = 0709819200, Transp_xNome = "MOTO HELP ENTREGAS RAPIDAS LTDA EPP", Transp_xLgr = "RUA SERRA AZUL 277", Transp_xMun = "CAMPINAS", Transp_UF = "SP", Transp_IE = 2147483647, qVol = 6070, esp = "Peca", error = null });
            Add(new NFe { CHNFE = 992346, nNF = 992346, Dest_CNPJ = 2147483647, Dest_xNome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL", Dest_xLgr = "Rua Jaragua", Dest_xBairro = "Bom Retiro", Dest_xMun = "Sao Paulo", Dest_UF = "SP", Dest_CEP = 01129000, Dest_fone = 33933501, Dest_IE = 2147483647, dEmit = "01/01/0001 00:00:00", dRecbto = "01/01/0001 00:00:00", hRecbto = "16:50:00", CNPJ = 2147483647, Emit_xNome = "Plotag Sistemas e Suprimentos Ltda", Emit_xLgr = "Rua Solon", Emit_xBairro = "Bom Retiro", Emit_xMun = "Sao Paulo", Emit_UF = "SP", Emit_CEP = 01127010, Emit_fone = 1123587604, Emit_IE = 2147483647, Emit_nro = 558, vBc = 0, vICMS = 0, vBCTS = 0, vProd = 690, vFrete = 0, vSeg = 0, vDesc = 0, vIPI = 0, vOutro = 0, vNF = 690, Transp_CNPJ = 2147483647, Transp_xNome = "MOTO HELP ENTREGAS RAPIDAS LTDA EPP", Transp_xLgr = "RUA SERRA AZUL 277", Transp_xMun = "CAMPINAS", Transp_UF = "SP", Transp_IE = 2147483647, qVol = 6070, esp = "Peca", error = null });
            
        }

        public NFe Add(NFe nfe)
        {
            if (nfe == null)
            {
                throw new ArgumentNullException("nNF");
            }
            nfes.Add(nfe);
            return nfe;
        }
        

        public IEnumerable<NFe> GetAll()
        {
            return nfes;
        }
        public NFe Get(int CHNFE)
        {
            return nfes.Find(s => s.CHNFE == CHNFE);
        }
    }
}