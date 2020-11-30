using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ProdController : ApiController
    {
        static readonly IEProdRepositorio prodRepositorio = new ProdRepositorio();

        public HttpResponseMessage GetAllProd()
        {
            List<Prod> listaProd = prodRepositorio.GetAll().ToList();
            return Request.CreateResponse<List<Prod>>(HttpStatusCode.OK, listaProd);
        }

        public HttpResponseMessage GetProd(int CHNFE)
        {
            Prod prods = prodRepositorio.Get(CHNFE);

            return Request.CreateResponse<Prod>(HttpStatusCode.OK, prods);

        }


    }
}