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

        public void Ingresar(string path, int filas, string nombre)
        {
            using (var Archivo = new FileStream(path, FileMode.Open))
            {
                using (var Reader = new BinaryReader(Archivo))
                {
                    var Longitud = Convert.ToInt32(Reader.BaseStream.Length);
                    var Buffer = new byte[Longitud];
                    Buffer = Reader.ReadBytes(Longitud);
                    var textocifrado = Cifradro(Buffer, filas);
                    EscribirCifrado(textocifrado, nombre);

                }
            }

        }

        private byte[] Cifradro(byte[] Texto, int Filas)
        {
            var Columnas = Texto.Length / Filas;
            Columnas = Columnas % 1 >= 0.5 ? Convert.ToInt32(Columnas) : Convert.ToInt32(Columnas) + 1;
            var Matriz = new byte[Columnas, Filas];
            var Caracter = new Queue<byte>();
            var Contador = 0;

            foreach (var item in Texto)
            {
                Caracter.Enqueue(item);
            }

            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < Columnas; j++)
                {
                    if (Contador < Texto.Length)
                    {
                        Matriz[j, i] = Caracter.Dequeue();
                        Contador++;
                    }
                    else
                    {
                        Matriz[j, i] = Convert.ToByte(Convert.ToChar(" "));
                    }
                     
                }
            }

            var TextoCifrado = new List<byte>();
             
            for (int i = 0; i < Columnas; i++)
            {
                for (int j = 0; j < Filas; j++)
                {
                   
                        TextoCifrado.Add(Matriz[i, j]);
                  
                }
            }
            return TextoCifrado.ToArray();
        }

        public void EscribirCifrado(byte[] TextoCipher ,string nombre_) 
        {
            var DireccionCarpetaCifrado = Environment.CurrentDirectory;

            if (!Directory.Exists(Path.Combine(DireccionCarpetaCifrado,"CifradosVertical")))
            {
                Directory.CreateDirectory(Path.Combine(DireccionCarpetaCifrado, "CifradosVertical"));
            }

            using (var streamer = new FileStream(Path.Combine(DireccionCarpetaCifrado, "CifradosVertical",$"{nombre_}.txt"),FileMode.OpenOrCreate))
            {
                using (var write = new BinaryWriter (streamer))
                {
                    write.Write(TextoCipher);
                }
            }
            

        }
        public void IngresoDecidrado(string path, int filas, string nombre)
        {
            using (var Archivo = new FileStream(path,FileMode.Open))
            {
                using (var Reader = new BinaryReader(Archivo))
                {
                    var Longuitd = Convert.ToInt32(Reader.BaseStream.Length);
                    var Buffer = new byte[Longuitd];
                    Buffer = Reader.ReadBytes(Longuitd);
                    var TextoDecifrado = Decifrar(Buffer, filas);
                    EscribirDecifrado(TextoDecifrado, nombre);
                    
                }
            }

        }

        private byte[] Decifrar(byte[] TextoCifrado, int Filas)
        {
            var Columnas = TextoCifrado.Length / Filas;
             
            var Matriz = new byte[Columnas, Filas];
           
            var Caracter = new Queue<byte>();
            

            foreach (var item in TextoCifrado)
            {
                Caracter.Enqueue(item);
            }

            for (int i = 0; i < Columnas; i++)
            {
                for (int j = 0; j < Filas; j++)
                {
                     
                        Matriz[i, j] = Caracter.Dequeue();
                       
                     

                }

            }
            var TextoDecifrado = new List<byte>();
             

            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < Columnas; j++)
                { 

                    TextoDecifrado.Add(Matriz[j, i]);
  
                }
            }

            return TextoDecifrado.ToArray();

        }


        public void EscribirDecifrado(byte[] TextoDecipher, string nombre_)
        {
            var DireccionCarpetaCifrado = Environment.CurrentDirectory;

            if (!Directory.Exists(Path.Combine(DireccionCarpetaCifrado, "DecifradosVertical")))
            {
                Directory.CreateDirectory(Path.Combine(DireccionCarpetaCifrado, "DecifradosVertical"));
            }

            using (var streamer = new FileStream(Path.Combine(DireccionCarpetaCifrado, "DecifradosVertical", $"{nombre_}.txt"), FileMode.OpenOrCreate))
            {
                using (var write = new BinaryWriter(streamer))
                {
                    write.Write(TextoDecipher);
                }
            }


        }


    }
}
