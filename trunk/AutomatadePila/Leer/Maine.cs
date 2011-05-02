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
            Alfabeto alfabetoLenguaje = new Alfabeto();
            Alfabeto alfabetoPila = new Alfabeto();
            lectur = new Lectura();
            auto = new Automata();
            ArrayList funcionesTransicion = new ArrayList();
            List<int> estados;
            List<int> listaFinales;
            List<char> listaAlfaLenguaje;
            List<char> listaAlfaPila;
            EstadosManager estadosManager = new EstadosManager();

            int x = lectur.numLinea();
            string[,] palabras = new string[x, 10];
            string[] estadosIniciales;
            string[] StringalfabetoLenguaje;
            string[] StringAlfabetoPila;
            string[] estadosFinales;
            palabras = lectur.leerArchivo(x);

            estadosIniciales = auto.estadosIniciales(palabras);
            estadosFinales = auto.estadosFinales(palabras, x);
            StringalfabetoLenguaje = auto.alfabetoLenguaje(palabras);
            StringAlfabetoPila = auto.alfabetoPila(palabras);
            funcionesTransicion = auto.funcioinesTransicion(palabras, x);
            estados = Separar(estadosIniciales[0]);
            listaFinales = Separar(estadosFinales[0]);
            listaAlfaLenguaje = SepararString(StringalfabetoLenguaje[0]);
            listaAlfaPila = SepararString(StringAlfabetoPila[0]);
            


            Console.WriteLine("Estados: {0}", estadosIniciales[0]);
            Console.WriteLine("Alfabeto del Lenguaje: {0}", StringalfabetoLenguaje[0]);
            Console.WriteLine("Alfabeto de Pila: {0}", StringAlfabetoPila[0]);
            Console.WriteLine("Funciones de Transición: ");
            auto.PrintValues(funcionesTransicion);
            Console.WriteLine("Estados Finales: {0}", estadosFinales[0]);
            Console.ReadLine();

            foreach (int i in estados)
            {
                estadosManager.agregarEstado(i);
            }
            foreach (int i in listaFinales)
            {
                estadosManager.declararEstadoFinal(i);
            }

            estadosManager.declararEstadoInicial(1);

            foreach (char c in listaAlfaLenguaje)
            {
                alfabetoLenguaje.agregarElemento(c);
            }
            foreach (char c in listaAlfaPila)
            {
                alfabetoPila.agregarElemento(c);
            }
            Console.WriteLine("WIIII");
            Console.WriteLine(estadosManager.estados);
            Console.WriteLine(estadosManager.estadosFinales);
            Console.WriteLine(estadosManager.estadosIniciales);
            Console.WriteLine(alfabetoLenguaje);
            Console.WriteLine(alfabetoPila);


            List<FuncionDeTransicion> funciones = new List<FuncionDeTransicion>();
            foreach (string funcion in funcionesTransicion)
            {
                funciones.Add(Lectura.LeerString(funcion));
            }
            Console.WriteLine(funciones.ElementAt(0));
            Console.ReadLine();


        }

        public static List<int> Separar(string palabra)
        {
            List<int> lista = new List<int>();
            char[] delimiterChars = { ',', '(', ')', '=', '{', '}', ' ' };
            string[] words = palabra.Split(delimiterChars);
            foreach (string s in words)
            {
                if (s.Trim() != "")
                {
                    int num;
                    num = int.Parse(s);
                    lista.Add(num);

                }
            }
            return lista;
        }
        public static List<char> SepararString(string palabra)
        {
            List<char> lista = new List<char>();
            char[] delimiterChars = { ',', '(', ')', '=', '{', '}', ' ' };
            string[] words = palabra.Split(delimiterChars);
            foreach (string s in words)
            {
                if (s.Trim() != "")
                {
                    lista.Add(s[0]);
                }
            }
            return lista;
        }
    }
}