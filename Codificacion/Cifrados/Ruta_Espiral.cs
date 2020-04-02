using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Codificacion.Cifrados
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

       public int bufferLength = 100000;
       string texto = string.Empty;
       public string textoMatriz = string.Empty;
        #region Cifrado
        public void Ingresar(string path, int filas,string nombre)
        {
            var byteBuffer = new byte[bufferLength];
            using (var archivo = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (var reader = new BinaryReader(archivo))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        byteBuffer = reader.ReadBytes(bufferLength);
                        foreach (char letra in byteBuffer)
                        {
                            if (letra != 0)
                            {
                                texto += letra;
                            }
                        }
                    }
                }
            }
            GenerarMatrizCifrado(filas);
            EscribirEnArchivoCifrado(textoMatriz, nombre);
        }
        public void GenerarMatrizCifrado(int valorM)
        {
            var valorN = this.texto.Length / valorM;
            int contadorTexto = 0;
            if (this.texto.Length % valorM != 0)
            {
                valorN++;
            }
            char[,] matriz = new char[valorM, valorN];
           
                for (int p = 0; p < valorM; p++)
                {
                    for (int j = 0; j < valorN; j++)
                    {
                        if (contadorTexto != texto.Length)
                        {
                            matriz[p, j] = texto[contadorTexto];
                            contadorTexto++;
                        }
                        else
                        {
                            matriz[p, j] = Convert.ToChar(36);
                        }
                    }
                }
                 Recorrido(valorM, valorN, matriz);
          
        }       
            public void Recorrido(int valorM, int valorN, char[,] matriz)
        {
            //recorriendo matriz en esprial
            int i, auxiliarM = 0, auxiliarN = 0;
            while (auxiliarM < valorM && auxiliarN < valorN)
            {
                for (i = auxiliarM; i < valorM; ++i)
                {
                    textoMatriz += matriz[i, auxiliarN];
                }
                auxiliarN++;
                for (i = auxiliarN; i < valorN; ++i)
                {
                    textoMatriz += matriz[valorM - 1, i];
                }
                valorM--;
                if (auxiliarN < valorN)
                {
                    for (i = valorM - 1; i >= auxiliarM; --i)
                    {
                        textoMatriz += matriz[i, valorN - 1];
                    }
                    valorN--;
                }
                if (auxiliarM < valorM)
                {
                    for (i = valorN - 1; i >= auxiliarN; --i)
                    {
                        textoMatriz += matriz[auxiliarM, i];
                    }
                    auxiliarM++;
                }
            }
            
        }
        public void EscribirEnArchivoCifrado(string texto, string nombre_) 
        {
            string CarpetaEspiralCifrado = Environment.CurrentDirectory;
            if (!Directory.Exists(Path.Combine(CarpetaEspiralCifrado, "CifradoEspiral")))
            {
                Directory.CreateDirectory(Path.Combine(CarpetaEspiralCifrado, "CifradoEspiral"));
            }
            using (var writeStream = new FileStream(Path.Combine(CarpetaEspiralCifrado, "CifradoEspiral", $"{nombre_}.text"), FileMode.OpenOrCreate))
            {
                using (var writer = new BinaryWriter(writeStream))
                {
                    writer.Seek(0, SeekOrigin.End);
                    writer.Write(System.Text.Encoding.Unicode.GetBytes(texto));
                }
            }
            textoMatriz = string.Empty;

        }
        #endregion
        #region Desifrado
        public void IngresoDecidrado(string path, int filas, string nombre)
        {

            var byteBuffer = new byte[bufferLength];
            using (var archivo = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (var reader = new BinaryReader(archivo))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        byteBuffer = reader.ReadBytes(bufferLength);
                        foreach (char letra in byteBuffer)
                        {
                            if (letra != 0)
                            {
                                texto += letra;
                            }
                        }
                    }
                }
            }
            GenerarMatrizDecifrado(filas,nombre);
        }
        public void GenerarMatrizDecifrado(int valorM, string nombre)
        {
            var valorN = this.texto.Length / valorM;
            int contadorTexto = 0;
            if (this.texto.Length % valorM != 0)
            {
                valorN++;
            }
            var x = valorM;
            var y = valorN;

            char[,] matriz = new char[valorM, valorN];
           
                int i, AuxM = 0, AuxN = 0;
                while (AuxM < valorM && AuxN < valorN)
                {
                    for (i = AuxM; i < valorM; ++i)
                    {
                        matriz[i, AuxN] = texto[contadorTexto];
                        contadorTexto++;
                    }
                    AuxN++;
                    for (i = AuxN; i < valorN; ++i)
                    {
                        matriz[valorM - 1, i] = texto[contadorTexto];
                        contadorTexto++;
                    }
                    valorM--;
                    if (AuxN < valorN)
                    {
                        for (i = valorM - 1; i >= AuxM; --i)
                        {
                            matriz[i, valorN - 1] = texto[contadorTexto];
                            contadorTexto++;
                        }
                        valorN--;
                    }
                    if (AuxM < valorM)
                    {
                        for (i = valorN - 1; i >= AuxN; --i)
                        {
                            matriz[AuxM, i] = texto[contadorTexto];
                            contadorTexto++;
                        }
                        AuxM++;
                    }
                }
                var textoDecifrado = string.Empty;
                for (int p = 0; p < x; p++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        if (matriz[p, j] != 36)
                        {
                            textoDecifrado += matriz[p, j];

                        }
                    }
                }                      
            EscribirEnArchivoDecifrado(textoDecifrado,nombre);
        }
        public void EscribirEnArchivoDecifrado(string texto, string Nombre)
        {

            string CarpetaEspiralDescifrado = Environment.CurrentDirectory;
            if (!Directory.Exists(Path.Combine(CarpetaEspiralDescifrado, "DescifradoEspiral")))
            {
                Directory.CreateDirectory(Path.Combine(CarpetaEspiralDescifrado, "DescifradoEspiral"));
            }
            using (var writeStream = new FileStream(Path.Combine(CarpetaEspiralDescifrado, "DescifradoEspiral", $"{Nombre}.text"), FileMode.OpenOrCreate))
            {
                using (var writer = new BinaryWriter(writeStream))
                {
                    writer.Seek(0, SeekOrigin.End);
                    writer.Write(System.Text.Encoding.Unicode.GetBytes(texto));
                }
            }
            textoMatriz = string.Empty;
        }
        #endregion
    }
}
