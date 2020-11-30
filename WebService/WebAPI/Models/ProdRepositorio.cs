using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ProdRepositorio : IEProdRepositorio
    {
        //private int _nextIEN = 1;

        private List<Prod> prods = new List<Prod>();

        public ProdRepositorio()
        {
            Add(new Prod { CHNFE = 648577, cProd = "GH96-08090A", nNF = 648577, xProd = "ACUMULADOR ELETRICO DE ION-LITIO RECARR - EAN:", NCM = 85076000, CFOP = 5901, uCom = "PC", qCom = 1120, vUnCom = 13, vProd = 14101 });
            Add(new Prod { CHNFE = 648577, cProd = "B17025051", nNF = 992346, xProd = "PAPEL MAXPLOT- 170MX250MX56GRS 3", NCM = 48025599, CFOP = 5101, uCom = "Rl", qCom = 1, vUnCom = 138, vProd = 138 });
        }

        public Prod Add(Prod prod)
        {
            if (prod == null)
            {
                throw new ArgumentNullException("nNF");
            }
            prods.Add(prod);
            return prod;
        }


        public IEnumerable<Prod> GetAll()
        {
            return prods;
        }
        public Prod Get(int CHNFE)
        {
            return prods.Find(s => s.CHNFE == CHNFE);
        }
    }
}