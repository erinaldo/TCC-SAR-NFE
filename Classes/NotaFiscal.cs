using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tingle.Classes.Propri;

namespace Tingle.Classes
{
    class NotaFiscal
    {
        public Ide ide { get; set; }
        public Emit emit { get; set; }
        public Dest dest { get; set; }
        public Imposto imposto { get; set; }
        public Transp transporte { get; set; }
        public infAdic infAdic { get; set; }
        public TribTotal total { get; set; }
    }
}
