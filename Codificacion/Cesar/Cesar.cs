using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Codificacion.Cesar
{
    public class Cesar
    {
        private static Cesar _instance = null;
        public static Cesar Instance
        {
            get
            {
                if (_instance == null) _instance = new Cesar();
                return _instance;
            }
        }

        public void Ingresar(string path)
        {            
            var archivo = new StreamReader(path);
            var linea = archivo.ReadLine();
        }
        public void IngresoDecidrado()
        {

        }
    }
}
