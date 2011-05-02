using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Leer
{
    public class FuncionDeTransicion
    {
        public Estado estadoCondicion;
        public char elementoCondicion;
        public char elementoCondicionTopeDePila;

        public Estado nuevoEstado;
        public char elementoMeterEnPila;

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
            toString = "Función: ("+this.estadoCondicion+", "+this.elementoCondicion+", "+this.elementoCondicionTopeDePila+" ) => {( "+this.nuevoEstado+", "+this.elementoMeterEnPila+")}";
            return toString;
        }
    }
}
