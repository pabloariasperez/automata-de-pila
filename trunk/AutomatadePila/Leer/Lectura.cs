using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Leer
{
    public class Lectura
    {
        public void Separar(string text)
        {
            char[] delimiterChars = {',','(',')','=','{','}'};
            string[] words = text.Split(delimiterChars);
            System.Console.WriteLine("Original text: '{0}'", text);
            System.Console.WriteLine("{0} words in text:", words.Length);

            foreach (string s in words)
            {
                System.Console.WriteLine(s);
            }
            System.Console.ReadLine();

        }

        public string [,] leerArchivo(int x)
        {
            string [,] palabras = new string [x,10];
            int contador = 0;
            try
            {
                using (StreamReader sr = new StreamReader("./../../Text.txt"))
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
                using (StreamReader sr = new StreamReader("./../../Text.txt"))
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
