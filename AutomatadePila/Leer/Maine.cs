using System;
using System.Collections.Generic;
using System.Collections;
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
           ArrayList funcionesTransicion = new ArrayList();
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
           funcionesTransicion = auto.funcioinesTransicion(palabras,x);

           Console.WriteLine("Estados: {0}",estadosIniciales[0]);
           Console.WriteLine("Alfabeto del Lenguaje: {0}",alfabetoLenguaje[0]);
           Console.WriteLine("Alfabeto de Pila: {0}",alfabetoPila[0]);
           Console.WriteLine("Funciones de Transición: ");
           auto.PrintValues(funcionesTransicion);
           Console.WriteLine("Estados Finales: {0}", estadosFinales[0]);
           Console.ReadLine();

           
        }
    }
}
