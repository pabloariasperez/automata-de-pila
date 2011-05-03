using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leer
{
    class ProcesadorPalabra
    {
        private List<FuncionDeTransicion> funcionDeTransicion;
        private EstadosManager estadosManager;
        private Alfabeto alfabetoLenguaje;
        private Alfabeto alfabetoPila;

        private Estado estadoActual;
        private char elementoActual;
        Stack<char> pilaDeAutomata;

        public ProcesadorPalabra(List<FuncionDeTransicion> funciones, EstadosManager estadosManager, Alfabeto alfabetoLenguaje, Alfabeto alfabetoPila)
        {
            //VAlores de DEFINICIÓN del autómata de pila
            this.funcionDeTransicion = funciones;
            this.estadosManager = estadosManager;
            this.alfabetoLenguaje = alfabetoLenguaje;
            this.alfabetoPila = alfabetoPila;

            //VAlores de trabajo para la palabra
            this.pilaDeAutomata = new Stack<char>();

        }

        public void probarPalabra(string palabraAProbar)
        {
            bool seAceptaLaPalabra = false;
            if (!palabraUsaAlfabeto(palabraAProbar))
            {
                Console.WriteLine("No se acepta. La palabra no respeta el alfabeto del lenguaje");
                return;
            }


            this.estadoActual = this.estadosManager.getEstadoInicial();
            Stack<char> palabra = new Stack<char>();
            pilaDeAutomata.Clear();
            char[] letras;
            char[] pila;
            for (int c = palabraAProbar.Length - 1; c >= 0; c--)
            {
                palabra.Push(palabraAProbar[c]);
            }


            letras = palabra.ToArray();
            Console.Write("(" + this.estadoActual + ", ");
            if (palabra.Count == 0)
            {
                Console.Write(Alfabeto.LAMBDA);
            }
            else
            {
                foreach (char c in letras)
                {
                    Console.Write(c + " ");
                }
            }
            Console.Write(", ");
            pila = pilaDeAutomata.ToArray();
            if (pilaDeAutomata.Count == 0)
            {
                Console.Write(Alfabeto.LAMBDA);
            }
            else
            {
                foreach (char c in pila)
                {
                    Console.Write(c + " ");
                }
            }
            this.elementoActual = palabra.Peek();


            for (int indexElement = 0; indexElement < funcionDeTransicion.Count; indexElement++)
            {
                //Revisamos las condiciones de finalización

                FuncionDeTransicion funcionEnCurso = funcionDeTransicion.ElementAt(indexElement);

                //Pregunto si el Estado Actual es el mismo que el Estado Condición de la función en curso.
                bool sonElMismoEstadoActualCondicion = this.estadoActual.CompareTo(funcionEnCurso.estadoCondicion) == 0;
                if (sonElMismoEstadoActualCondicion)
                {
                    //Pregunto si el Elemento Actual es el mismo que el Elemento Condición de la Función en curso
                    bool esLambdaLaCondicion = funcionEnCurso.elementoCondicion == Alfabeto.LAMBDA;
                    bool sonLoMismoActualYCondicion = this.elementoActual == funcionEnCurso.elementoCondicion;

                    //Console.Write(funcionEnCurso.elementoCondicion + " - " + this.elementoActual);

                    if (esLambdaLaCondicion || sonLoMismoActualYCondicion)
                    {
                        //Pregunto por la condición para el stack
                        bool esLambdaCondicionDePila = funcionEnCurso.elementoCondicionTopeDePila == Alfabeto.LAMBDA;
                        bool esTopeDePilaActualLaCondicion;
                        if (this.pilaDeAutomata.Count != 0)
                        {
                            esTopeDePilaActualLaCondicion = this.pilaDeAutomata.Peek() == funcionEnCurso.elementoCondicionTopeDePila;
                        }
                        else
                        {
                            esTopeDePilaActualLaCondicion = false;
                        }

                        if (esTopeDePilaActualLaCondicion || esLambdaCondicionDePila)
                        {
                            Console.WriteLine(") |- ");
                            this.estadoActual = funcionEnCurso.nuevoEstado;


                            if (!esLambdaCondicionDePila && this.pilaDeAutomata.Count != 0)
                            {
                                this.pilaDeAutomata.Pop();
                            }

                            bool esLambdaElElementoMeterEnPila = funcionEnCurso.elementoMeterEnPila == Alfabeto.LAMBDA;
                            if (!esLambdaElElementoMeterEnPila)
                            {
                                this.pilaDeAutomata.Push(funcionEnCurso.elementoMeterEnPila);
                            }

                            //Como hubo cambio de estado, reiniciamos el indexElement para volver a repasar todas las funciones
                            indexElement = -1;

                            if (palabra.Count != 0 && !esLambdaLaCondicion)
                            {
                                palabra.Pop();
                            }

                            if (palabra.Count > 0)
                            {
                                this.elementoActual = palabra.Peek();
                            }
                            else if (palabra.Count == 0)
                            {
                                this.elementoActual = Alfabeto.VACIO;
                            }

                            letras = palabra.ToArray();
                            Console.Write("(" + this.estadoActual + ", ");
                            if (palabra.Count == 0)
                            {
                                Console.Write(Alfabeto.LAMBDA);
                            }
                            else
                            {
                                foreach (char c in letras)
                                {
                                    Console.Write(c + " ");
                                }
                            }
                            Console.Write(", ");
                            pila = pilaDeAutomata.ToArray();
                            if (pilaDeAutomata.Count == 0)
                            {
                                Console.Write(Alfabeto.LAMBDA);
                            }
                            else
                            {
                                foreach (char c in pila)
                                {
                                    Console.Write(c + " ");
                                }
                            }
                        }
                    }
                }

                if (this.estadosManager.estadosFinales.contengoA(this.estadoActual) == true &&
                        palabra.Count == 0 &&
                        this.pilaDeAutomata.Count == 0
                    )
                {
                    seAceptaLaPalabra = true;
                    break;
                }

            }

            Console.WriteLine(")");
            if (seAceptaLaPalabra)
            {

                Console.WriteLine("\nSí se acepta la palabra " + "'" + palabraAProbar + "'" + " =)");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\nNo se acepta la palabra " + "'" + palabraAProbar + "'" + " =(");
            }

            Console.ReadLine();

        }

        public bool palabraUsaAlfabeto(string palabra)
        {
            for (int c = 0; c < palabra.Length; c++)
            {
                if (!alfabetoLenguaje.contieneA(palabra[c]))
                {
                    return false;
                }
            }
            return true;
        }

    }
}

