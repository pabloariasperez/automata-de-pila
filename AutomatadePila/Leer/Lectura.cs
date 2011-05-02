using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Leer
{
    public class Lectura
    {
        public static FuncionDeTransicion LeerString(string text)
        {
            Estado estadoCondicion;
            char elementoCondicion;
            char elementoCondicionTopeDePila;

            Estado nuevoEstado;
            char elementoMeterEnPila;

            char[] delimiterChars = { ',', '(', ')', '=', '{', '}', ' ' };

            string[] words = text.Split(delimiterChars);
            ArrayList lineas = new ArrayList();

            foreach (string s in words)
            {
                if (s.Trim() != "")
                {
                    lineas.Add(s);
                }
            }

            estadoCondicion = new Estado(((string)(lineas[0])).ToCharArray()[0] - '0');
            elementoCondicion = ((string)(lineas[1])).ToCharArray()[0];
            elementoCondicionTopeDePila = ((string)(lineas[2])).ToCharArray()[0];

            nuevoEstado = new Estado(((string)(lineas[3])).ToCharArray()[0] - '0');
            elementoMeterEnPila = ((string)(lineas[4])).ToCharArray()[0];

            FuncionDeTransicion funcion = new FuncionDeTransicion(estadoCondicion, nuevoEstado, elementoCondicion, elementoCondicionTopeDePila, elementoMeterEnPila);
            return funcion;
        }

        public string [,] leerArchivo(int x)
        {
            string [,] palabras = new string [x,10];
            int contador = 0;
            try
            {
                //./../../Text.txt
                using (StreamReader sr = new StreamReader("Text.txt"))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        for (int i = 0+contador; i < x; i++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                palabras [i,j] = line; 
                            }
                        }
                        contador++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return palabras;
        }

        public int numLinea()
        {
            int contador = 0;
                using (StreamReader sr = new StreamReader("Text.txt"))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        contador++;
                    }
    
                }
            return contador;
            
        }

        public void imprimirArreglo (int x, string [,] palabras){

            for (int i = 0; i < x; i++)
            {
                Console.WriteLine("{0}",i);
                for (int j = 0; j < 1; j++)
                {
                    Console.WriteLine("{0}",palabras [i,j]);
                }
            }
            Console.ReadLine();

        }
    }
}
