using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codificacion.Cifrados
{
    public class ZigZag
    {
        private static ZigZag _instance = null;
        public static ZigZag Instance
        {
            get
            {
                if (_instance == null) _instance = new ZigZag();
                return _instance;
            }
        }
        public void Ingresar(string path, int carriles)
        {

        }
        public void DecifrarIngresar( )
        {

        }
    }
}
