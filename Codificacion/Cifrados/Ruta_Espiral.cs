using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Codificacion.Cifrados2
{
    public class Ruta_Espiral
    {
        private static Ruta_Espiral _instance = null;
        public static Ruta_Espiral Instance
        {
            get
            {
                if (_instance == null) _instance = new Ruta_Espiral();
                return _instance;
            }
        }

        public void Ingresar(string path, int filas)
        {
            var archivo = new StreamReader(path);
            var linea = archivo.ReadLine();

        }
 
        public void IngresoDecidrado()
        {

        }


 
    }
}
