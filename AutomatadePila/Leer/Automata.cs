using System;
using System.Collections.Generic;
using System.Collections;
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
                   
                }
                else
                {
                    estados[0] = palabra[x, 0];
                    break;
                }
            }
            
            return estados;
        }
        public ArrayList funcioinesTransicion(string[,] palabra, int y)
        {
            ArrayList estados = new ArrayList();
             for (int x = 3; x < y; x++)
            {
                if (palabra[x, 0].IndexOf("(") != -1)
                {
                    
                    estados.Add(palabra[x,0]);
                }
                else
                {
                    break;
                }
            }
            return estados;
        }
        public void PrintValues( IEnumerable myList )  {
            foreach ( Object obj in myList )
            Console.WriteLine( "{0}", obj );
   }

}

    }
