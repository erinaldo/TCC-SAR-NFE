using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class NFeController : ApiController
    {
            static readonly IENFeRepositorio nfeRepositorio = new NFeRepositorio();
            
            public HttpResponseMessage GetAllNFe()
            {
                List<NFe> listaNFe = nfeRepositorio.GetAll().ToList();
                return Request.CreateResponse<List<NFe>>(HttpStatusCode.OK, listaNFe);
            }

            public HttpResponseMessage GetNFe(int CHNFE)
            {
               NFe nfes = nfeRepositorio.Get(CHNFE);
                if (CHNFE == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Estudante não localizado para o Id informado");
                }
                else
                {
                    return Request.CreateResponse<NFe>(HttpStatusCode.OK, nfes);
                }
            }
            
        
    }
}
