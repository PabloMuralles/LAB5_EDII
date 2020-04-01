using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Codificacion.Cifrados
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
        List<char> Texto_cifrado = new List<char>();
        public void Ingresar(string path)
        {
            var archivo = new StreamReader(path);
            var linea = archivo.ReadLine();
            int tamaño = linea.Length;
            char[] caracter = new char[tamaño];
            for (int i = 0; i < tamaño; i++)
            {
                int posicion = (int)linea[i];
                caracter[i] = (char)(posicion + 3);
                Texto_cifrado.Add(caracter[i]);
            }
            Escribir();
        }
        public void Escribir()
        {
            StreamWriter Cesar = new StreamWriter(@"c:\Temp\compresion_cesar.txt");
            foreach (var item in Texto_cifrado)
            {
                Cesar.Write("{0}", Convert.ToString(item));
            }
            Cesar.Close();
        }
 
       
        public void IngresoDescifrado(string path)
        {
            var archivo = new StreamReader(path);
            var linea = archivo.ReadLine();
            int tamaño = linea.Length;
            char[] caracter = new char[tamaño];
            for (int i = 0; i < tamaño; i++)
            {
                int posicion = (int)linea[i];
                caracter[i] = (char)(posicion - 3);
                Texto_cifrado.Add(caracter[i]);
            }
            Escribir();
        }

 
    }
}
