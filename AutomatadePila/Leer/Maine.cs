using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leer
{
   public class Maine
    {

       public static void Main(string[] args)
        {
           Lectura lectur;
           Automata auto;
           lectur = new Lectura();
           auto = new Automata();
           int x = lectur.numLinea();
           string [,] palabras = new string[x,10];
           string[] estadosIniciales;
           string[] alfabetoLenguaje;
           string[] alfabetoPila;
           string[] estadosFinales;
           palabras = lectur.leerArchivo(x);

           estadosIniciales = auto.estadosIniciales(palabras);
           estadosFinales = auto.estadosFinales(palabras,x);
           alfabetoLenguaje = auto.alfabetoLenguaje(palabras);
           alfabetoPila = auto.alfabetoPila(palabras);

           Console.WriteLine("{0}",estadosIniciales[0]);
           Console.WriteLine("{0}",estadosFinales[0]);
           Console.WriteLine("{0}",alfabetoLenguaje[0]);
           Console.WriteLine("{0}",alfabetoPila[0]);



           Console.WriteLine();
           
           lectur.imprimirArreglo(x,palabras);
           for (int i = 0; i < x; i++)
           {
               for (int j = 0; j < 1; j++)
               {
                   lectur.Separar(palabras[i, j]);
               }
           }
        }
    }
}
