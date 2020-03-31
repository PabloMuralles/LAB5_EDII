using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Codificacion.Cifrados
{
    public class Ruta_Vertical
    {


        private static Ruta_Vertical _instance = null;
        public static Ruta_Vertical Instance
        {
            get
            {
                if (_instance == null) _instance = new Ruta_Vertical();
                return _instance;
            }
        }

        public void Ingresar(string path, int filas)
        {


        }
        public void IngresoDecidrado()
        {

        }
    }
}
