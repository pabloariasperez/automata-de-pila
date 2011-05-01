using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Leer
{
    class Automata
    {
        public string[] estadosIniciales(string[,] palabra)
        {
            string[] estados = new string[1];
            estados[0] = palabra[0, 0];
            return estados;
        }

        public string[] alfabetoLenguaje(string[,] palabra)
        {
            string[] estados = new string[1];
            estados[0] = palabra[1, 0];
            return estados;
        }
        public string[] alfabetoPila(string[,] palabra)
        {
            string[] estados = new string[1];
            estados[0] = palabra[2, 0];
            return estados;
        }
        public string[] estadosFinales(string[,] palabra,int y)
        {
            string[] estados = new string[1];

            for (int x = 3; x < y; x++)
            {
                if (palabra[x, 0].IndexOf("(") != -1)
                {
                    Console.WriteLine("Tiene (");
                }
                else
                {
                    estados[0] = palabra[x, 0];
                    break;
                }
            }
            Console.WriteLine("Estados Finales {0}", estados[0]);
            return estados;
        }
    }
}
