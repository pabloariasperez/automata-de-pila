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
            Console.WriteLine("* Automata de Pila v0.1, Desarrollado por: Pablo Arias y César Machuca * \n");
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
            bool wii = false;

            int x = lectur.numLinea();
            string[,] palabras = new string[x, 10];
            string[] estadosIniciales;
            string[] StringalfabetoLenguaje;
            string[] StringAlfabetoPila;
            string[] estadosFinales;
            palabras = lectur.leerArchivo(x);
            String word;

            estadosIniciales = auto.estadosIniciales(palabras);
            estadosFinales = auto.estadosFinales(palabras, x);
            StringalfabetoLenguaje = auto.alfabetoLenguaje(palabras);
            StringAlfabetoPila = auto.alfabetoPila(palabras);
            funcionesTransicion = auto.funcioinesTransicion(palabras, x);
            estados = Separar(estadosIniciales[0]);
            listaFinales = Separar(estadosFinales[0]);
            listaAlfaLenguaje = SepararString(StringalfabetoLenguaje[0]);
            listaAlfaPila = SepararString(StringAlfabetoPila[0]);


            Console.WriteLine("Datos obtenidos desde el archivo Text.txt: \n");
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

            Console.WriteLine("Escribe tu estado inicial: ");
            string ini = Console.ReadLine();
            int inicial = int.Parse(ini);
            Console.WriteLine();

            estadosManager.declararEstadoInicial(inicial);

            foreach (char c in listaAlfaLenguaje)
            {
                alfabetoLenguaje.agregarElemento(c);
            }
            foreach (char c in listaAlfaPila)
            {
                alfabetoPila.agregarElemento(c);
            }
            
            
            List<FuncionDeTransicion> funciones = new List<FuncionDeTransicion>();
            foreach (string funcion in funcionesTransicion)
            {
                funciones.Add(Lectura.LeerString(funcion));
            }

            ProcesadorPalabra demo = new ProcesadorPalabra(funciones, estadosManager, alfabetoLenguaje, alfabetoPila);
            while (wii == false)
            {
                Console.WriteLine("Escriba la palabra a procesar: ");
                word = obtenerPalabra();
                Console.ReadLine();
                Console.WriteLine("DESCRIPCIÓN INSTANTANEA: \n ");
                demo.probarPalabra(word);
                Console.WriteLine("¿Quiére usar otra palabar? (y/n)");
                string respuesta = Console.ReadLine();
                switch (respuesta)
                {
                    case "y":
                        wii = false;
                        Console.WriteLine();
                        break;
                    case "n":
                        wii = true;
                        Console.WriteLine();
                        break;
                    default:
                        wii = true;
                        Console.WriteLine("ERROR: Opción Invalida");
                        break;
                }



            }

            
            Console.WriteLine("Presiona Enter para salir.");
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
        public static string obtenerPalabra() 
        {
            string palabra;
            palabra = Console.ReadLine();
            while (palabra == "")
            {
                Console.WriteLine("ERROR: PALABRA NO VALIDA");
                Console.WriteLine("Escriba una palabra valida: ");
                palabra = Console.ReadLine();
            }

            return palabra;

            
        }
    }
}