using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Codificacion.Cifrados
{
    public class ZigZag
    {
        private static ZigZag _instance = null;
        public static ZigZag Instance
        {
            get
            {
                if (_instance == null) _instance = new ZigZag();
                return _instance;
            }
        }
        public void Ingresar(string path, int niveles, string nombre)
        {
            using (var archivo = new FileStream(path, FileMode.Open))
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
            var ElemetosXola = (2 * niveles_) - 2;
            var CantidadOlas = (Texto.Length) / ElemetosXola;
            CantidadOlas = CantidadOlas % 1 >= 0.5 ? Convert.ToInt32(CantidadOlas) : Convert.ToInt32(CantidadOlas) + 1;
            var ElementosTotales = ElemetosXola * CantidadOlas;
            var TextoCompleto = new byte[ElementosTotales];

            if (ElementosTotales != Texto.Length)
            {

                for (int i = 0; i < Texto.Length; i++)
                {
                    TextoCompleto[i] = Texto[i];
                }

                for (int i = Texto.Length; i < ElementosTotales; i++)
                {

                    TextoCompleto[i] = Convert.ToByte(Convert.ToChar(" "));
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

            var Posicion = 0;
            var Incrementador = 1;
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


        private void Escritura(byte[] TextoCifrado, string nombre_)
        {
            string CarpetaZigzagCifrado = Environment.CurrentDirectory;

            if (!Directory.Exists(Path.Combine(CarpetaZigzagCifrado, "CifradoZigZag")))
            {
                Directory.CreateDirectory(Path.Combine(CarpetaZigzagCifrado, "CifradoZigZag"));
            }

            using (var streamwriter = new FileStream(Path.Combine(CarpetaZigzagCifrado, "CifradoZigZag", $"{nombre_}.txt"), FileMode.OpenOrCreate))
            {
                using (var write = new BinaryWriter(streamwriter))
                {
                    write.Write(TextoCifrado);
                }

            }

        }


        public void IngresarDecifrado(string path, int niveles, string nombre)
        {
            using (var Archivo = new FileStream(path, FileMode.Open))
            {
                using (var Reader = new BinaryReader(Archivo))
                {
                    var Longitud = Convert.ToInt32(Reader.BaseStream.Length);
                    var buffer = new byte[Longitud];
                    buffer = Reader.ReadBytes(Longitud);
                    var TextoDecifrado = Decifrar(buffer, niveles);
                    EscrituraDecifrado(TextoDecifrado, nombre);

                }

            }

        }

        private byte[] Decifrar(byte[] TextoCifrado, int niveles)
        {
             

            var NivelesIntermedio = niveles - 2;

            var CaracteresNivelesNoIntermedios = TextoCifrado.Length / (2 + (2 * NivelesIntermedio));

            var CantidadCaracterIntermedio = TextoCifrado.Length - (2 * CaracteresNivelesNoIntermedios);

            var IntervalosCaracteresIntermedio = CantidadCaracterIntermedio / NivelesIntermedio;

            var IntervalosIntermedios = CantidadCaracterIntermedio / IntervalosCaracteresIntermedio;

            var CantidadEspaciosListas = 2 + IntervalosIntermedios;

            var CaracteresDivididos = new Queue<byte>[CantidadEspaciosListas];

            for (int i = 0; i < CantidadEspaciosListas; i++)
            {
                CaracteresDivididos[i]= new Queue<byte>();
            }

            var ContadorNiveles = 1;
            var Posicion = 0;
            var ContadorCaracteresIntermedio = 1;

            foreach (var item in TextoCifrado)
            {
                if (Posicion < CaracteresNivelesNoIntermedios)
                {
                    CaracteresDivididos[0].Enqueue(item);
                    
                }
                else
                {
                    if (Posicion == CaracteresNivelesNoIntermedios)
                    {
                        CaracteresDivididos[ContadorNiveles].Enqueue(item);
                        
                  
                    }
                    else
                    {
                        if (ContadorCaracteresIntermedio < IntervalosCaracteresIntermedio)
                        {
                            CaracteresDivididos[ContadorNiveles].Enqueue(item);
                            ContadorCaracteresIntermedio++;
                        }
                        else
                        {
                            if (ContadorNiveles == niveles - 1 )
                            {
                                CaracteresDivididos[ContadorNiveles].Enqueue(item);
                            }
                            else
                            {
                                ContadorCaracteresIntermedio = 1;
                                ContadorNiveles++;
                                CaracteresDivididos[ContadorNiveles].Enqueue(item);
                                 
                            }
                        }
                    }
                }
                Posicion++;
            }

            var Movimiento = 0;
            var NivelCaracter  = 0;
            var TextoDecifrado = new List<byte>();

            var contadroasdfj = 0;
             

            while (CaracteresDivididos[0].Count != 0 || CaracteresDivididos[niveles - 1].Count != 0 || CaracteresDivididos[1].Count != 0)
            {
                if (contadroasdfj == 28)
                {

                }
                if (NivelCaracter == 0)
                {
                    TextoDecifrado.Add(CaracteresDivididos[NivelCaracter].Dequeue());
                    NivelCaracter++;
                    Movimiento = 0;
                }
                else
                {
                    if (NivelCaracter < niveles - 1 && Movimiento == 0 )
                    {
                        TextoDecifrado.Add(CaracteresDivididos[NivelCaracter].Dequeue());
                        NivelCaracter++;
                    }
                    else
                    {
                        if (NivelCaracter > 0 && Movimiento == 1)
                        {
                            TextoDecifrado.Add(CaracteresDivididos[NivelCaracter].Dequeue());
                            NivelCaracter--;
                        }
                        else
                        {
                            if (NivelCaracter == niveles - 1)
                            {
                                TextoDecifrado.Add(CaracteresDivididos[NivelCaracter].Dequeue());
                                Movimiento = 1;
                                NivelCaracter = niveles - 2;

                            }
                        }
                    }
                }
                contadroasdfj++;
            }
            return TextoDecifrado.ToArray();


        }



        private void EscrituraDecifrado(byte[] TextoDecifrado, string nombre_)
        {
            string CarpetaZigzagCifrado = Environment.CurrentDirectory;

            if (!Directory.Exists(Path.Combine(CarpetaZigzagCifrado, "DecifradoZigZag")))
            {
                Directory.CreateDirectory(Path.Combine(CarpetaZigzagCifrado, "DecifradoZigZag"));
            }

            using (var streamwriter = new FileStream(Path.Combine(CarpetaZigzagCifrado, "DecifradoZigZag", $"{nombre_}.txt"), FileMode.OpenOrCreate))
            {
                using (var write = new BinaryWriter(streamwriter))
                {
                    write.Write(TextoDecifrado);
                }

            }

        }
    }
}
