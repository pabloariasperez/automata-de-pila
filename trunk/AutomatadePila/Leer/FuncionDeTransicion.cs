using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Leer
{
    public class FuncionDeTransicion
    {
        private Estado estadoCondicion;
        private char elementoCondicion;
        private char elementoCondicionTopeDePila;

        private Estado nuevoEstado;
        private char elementoMeterEnPila;

        public FuncionDeTransicion(Estado estadoCondicion, Estado nuevoEstado, char elementoCondicion, char elementoTopeDePila, char elementoMeterEnPila)
        {
            this.estadoCondicion = estadoCondicion;
            this.nuevoEstado = nuevoEstado;
            this.elementoCondicion = elementoCondicion;
            this.elementoCondicionTopeDePila = elementoTopeDePila;
            this.elementoMeterEnPila = elementoMeterEnPila;
        }


        public override string ToString()
        {
            string toString;
            toString = "Estado condición: " + this.estadoCondicion + "\n";
            toString += "Elemento condición: " + this.elementoCondicion + "\n";
            toString += "Tope de pila: " + this.elementoCondicionTopeDePila + "\n";
            toString += "Nuevo Estado: " + this.nuevoEstado + "\n";
            toString += "Cambio en la pila: " + this.elementoMeterEnPila + "\n\n";
            return toString;
        }
    }
}
