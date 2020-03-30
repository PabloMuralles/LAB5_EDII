using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codificacion.Zig_Zag
{
    public class Zig_Zag
    {
        private static Zig_Zag _instance = null;
        public static Zig_Zag Instance
        {
            get
            {
                if (_instance == null) _instance = new Zig_Zag();
                return _instance;
            }
        }
        public void Ingresar(string path, int carriles)
        {
            var archivo = new StreamReader(path);
            var linea = archivo.ReadLine();
        }
    }
}
