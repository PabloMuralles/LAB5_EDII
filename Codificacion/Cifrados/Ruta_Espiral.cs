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

            //direccion = 0: vertical, direccion = 1: horizontal
            char[,] matriz = new char[valorM, valorN];
            //if (direccion)
            //{
                //llenando matriz horizontalmente
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

                 recorrerHaciaAbajo(valorM, valorN, matriz);
            //}
            //else
            //{
            //    //llenando matriz verticalmente
            //    for (int p = 0; p < valorN; p++)
            //    {
            //        for (int j = 0; j < valorM; j++)
            //        {
            //            if (contadorTexto != texto.Length)
            //            {
            //                matriz[j, p] = texto[contadorTexto];
            //                contadorTexto++;
            //            }
            //            else
            //            {
            //                matriz[j, p] = Convert.ToChar(36);
            //            }
            //        }
            //    }
            //     recorrerHaciaDerecha(valorM, valorN, matriz);
            //}
        }
        //public void recorrerHaciaDerecha(int valorM, int valorN, char[,] matriz)
        //{
        //    //recorriendo matriz en esprial
        //    int i, auxiliarM = 0, aulixiarN = 0;
        //    while (auxiliarM < valorM && aulixiarN < valorN)
        //    {
        //        for (i = aulixiarN; i < valorN; ++i)
        //        {
        //            textoMatriz += matriz[auxiliarM, i];
        //        }
        //        auxiliarM++;
        //        for (i = auxiliarM; i < valorM; ++i)
        //        {
        //            textoMatriz += matriz[i, valorN - 1];
        //        }
        //        valorN--;
        //        if (auxiliarM < valorM)
        //        {
        //            for (i = valorN - 1; i >= aulixiarN; --i)
        //            {
        //                textoMatriz += matriz[valorM - 1, i];
        //            }
        //            valorM--;
        //        }
        //        if (aulixiarN < valorN)
        //        {
        //            for (i = valorM - 1; i >= auxiliarM; --i)
        //            {
        //                textoMatriz += matriz[i, aulixiarN];
        //            }
        //            aulixiarN++;
        //        }

        //    }          
        //}
            public void recorrerHaciaAbajo(int valorM, int valorN, char[,] matriz)
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
        //@"c:\Temp\compresion_cesar.txt"
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
        public void IngresoDecidrado()
        {

        }
    }
}
