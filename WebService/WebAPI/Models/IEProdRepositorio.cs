using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    interface IEProdRepositorio
    {
        IEnumerable<Prod> GetAll();

        Prod Get(int CHNFE);
    }
}