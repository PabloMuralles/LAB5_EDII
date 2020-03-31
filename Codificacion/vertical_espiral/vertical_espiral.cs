 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

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

        public void Ingresar(string path, int filas)
        {
            var archivo = new StreamReader(path);
            var linea = archivo.ReadLine();

        }
    }
}
