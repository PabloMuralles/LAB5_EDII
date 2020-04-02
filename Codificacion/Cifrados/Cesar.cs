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
        public void Ingresar(string path,string Nombre)
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
            Escrituracifrado(Nombre);
        }
        public void Escrituracifrado(string Nombre)
        {
            string CarpetaCesarCifrar = Environment.CurrentDirectory;
            if (!Directory.Exists(Path.Combine(CarpetaCesarCifrar, "CifradoCesar")))
            {
                Directory.CreateDirectory(Path.Combine(CarpetaCesarCifrar, "CifradoCesar"));
            }
            using (var writeStream = new FileStream(Path.Combine(CarpetaCesarCifrar, "CifradoCesar", $"{Nombre}.text"), FileMode.OpenOrCreate))
            {
                string Texto = string.Empty;
              foreach (var item in Texto_cifrado)
              {
                     Texto = Texto + Convert.ToString(item) ;
              }
                using (var write = new BinaryWriter(writeStream))
                {
                    write.Write(Texto);
                }
            }                     
        }
        public void EscrituraDesifrado(string Nombre)
        {
            string CarpetaCesarDesifrar = Environment.CurrentDirectory;
            if (!Directory.Exists(Path.Combine(CarpetaCesarDesifrar, "DescifradoCesar")))
            {
                Directory.CreateDirectory(Path.Combine(CarpetaCesarDesifrar, "DescifradoCesar"));
            }
            using (var writeStream = new FileStream(Path.Combine(CarpetaCesarDesifrar, "DescifradoCesar", $"{Nombre}.text"), FileMode.OpenOrCreate))
            {
                string Texto = string.Empty;
                foreach (var item in Texto_cifrado)
                {
                    Texto = Texto + Convert.ToString(item);
                }
                using (var write = new BinaryWriter(writeStream))
                {
                    write.Write(Texto);
                }
            }
        }
 
       
        public void IngresoDescifrado(string path,string Nombre)
        {
            var archivo = new StreamReader(path);
            var linea = archivo.ReadLine();
            if (linea == null)
            {
                linea = archivo.ReadLine();
            }
            int tamaño = linea.Length;
            char[] caracter = new char[tamaño];
            for (int i = 0; i < tamaño; i++)
            {
                int posicion = (int)linea[i];
                caracter[i] = (char)(posicion - 3);
                Texto_cifrado.Add(caracter[i]);
            }
            EscrituraDesifrado(Nombre);
        }

 
    }
}
