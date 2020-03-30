using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
 

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
        public void Ingresar(string path, int niveles, string nombre)
        {
            using (var archivo = new FileStream(path,FileMode.OpenOrCreate))
            {
                using (var reader = new BinaryReader(archivo))
                {
                    var LongitudArchivo = Convert.ToInt32(reader.BaseStream.Length);
                    byte[] buffer = new byte[LongitudArchivo];
                    buffer = reader.ReadBytes(LongitudArchivo);
                    var ArchivoCifrado = Cifrado(buffer, niveles);
                    Escritura(ArchivoCifrado, nombre);
                    

                }

            }
        }

        private byte[] Cifrado(byte[] Texto, int niveles_)
        {
            var TextoCifrado = new List<string>();
            var Posicion = 0;
            var Incrementador = 1;
            var ElemetosXola = (2 * niveles_) - 2;
            var CantidadOlas = (Texto.Length) / ElemetosXola;
            CantidadOlas = CantidadOlas % 1 >= 0.5 ? Convert.ToInt32(CantidadOlas) : Convert.ToInt32(CantidadOlas) + 1;
            var ElementosTotales = ElemetosXola * CantidadOlas;

            var TextoCompleto = new byte[ElementosTotales];
            if (ElementosTotales!=Texto.Length)
            {

                for (int i = 0; i < Texto.Length; i++)
                {
                    TextoCompleto[i] = Texto[i];
                }

                for (int i = Texto.Length; i < ElementosTotales; i++)
                {
                
                    TextoCompleto[i] = Convert.ToByte(Convert.ToChar("$"));
                }

            }
            else
            {
                TextoCompleto = Texto;
            }
            
            for (int i = 0; i < niveles_; i++)
            {
                TextoCifrado.Add("");
            }

            foreach (var item in TextoCompleto)
            {
                if (Posicion + Incrementador == niveles_)
                {
                    Incrementador = -1;
                }
                else
                {
                    if (Posicion + Incrementador == -1)
                    {
                        Incrementador = 1;
                    }
                }

                TextoCifrado[Posicion] += Convert.ToString(Convert.ToChar(item));
                Posicion += Incrementador;
            }

            var CadenaCifrada = string.Empty;
            foreach (var item in TextoCifrado)
            {
                CadenaCifrada += item;
            }

            var TextoCifradoBytes = new List<byte>();
            foreach (var item in CadenaCifrada)
            {
                TextoCifradoBytes.Add(Convert.ToByte(Convert.ToChar(item)));
            }

            return TextoCifradoBytes.ToArray();
        }


        private void Escritura(byte[] TextoCifrado,string nombre_)
        {
            string CarpetaZigzagCifrado = Environment.CurrentDirectory;

            if (!Directory.Exists(Path.Combine(CarpetaZigzagCifrado,"CifradoZigZag")))
            {
                Directory.CreateDirectory(Path.Combine(CarpetaZigzagCifrado, "CifradoZigZag"));
            }

            using (var streamwriter = new FileStream(Path.Combine(CarpetaZigzagCifrado, "CifradoZigZag",$"{nombre_}.text"),FileMode.OpenOrCreate))
            {
                using (var write = new BinaryWriter(streamwriter))
                {
                    write.Write(TextoCifrado);
                }

            }

        }


        public void IngresarDecifrado(string path, int niveles, string nombre)
        {
            using (var Archivo = new FileStream(path,FileMode.OpenOrCreate))
            {
                using (var Reader = new BinaryReader(Archivo) )
                {
                    var Longitud = Convert.ToInt32(Reader.BaseStream.Length);
                    var buffer = new byte[Longitud];
                    buffer = Reader.ReadBytes(Longitud);
                    Decifrar(buffer, niveles);

                }

            }

        }
        private void Decifrar(byte[] TextoCifrado, int niveles)
        {
            var NivelesIntermedio = niveles - 2;

            var CaracteresNivelesNoIntermedios = TextoCifrado.Length;
          

            
        }
    }
}
