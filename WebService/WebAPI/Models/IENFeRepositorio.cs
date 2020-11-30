﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    interface IENFeRepositorio
    {
        IEnumerable<NFe> GetAll();

        NFe Get(int CHNFE);
    }
}
