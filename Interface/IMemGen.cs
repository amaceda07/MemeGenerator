using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemGen.Interface
{
    interface IMemGen
    {
        string Resultado(int imagenID, string texto);
    }
}
