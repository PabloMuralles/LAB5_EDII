 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codificacion.vertical_espiral
{
    public class vertical_espiral
    {
        private static vertical_espiral _instance = null;
        public static vertical_espiral Instance
        {
            get
            {
                if (_instance == null) _instance = new vertical_espiral();
                return _instance;
            }
        }
    }
}
