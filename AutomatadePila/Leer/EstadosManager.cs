using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leer
{
    public class EstadosManager
    {
        public ConjuntoDeEstados estados;
        public ConjuntoDeEstados estadosIniciales;
        public ConjuntoDeEstados estadosFinales;

        public EstadosManager()
        {
            this.estados = new ConjuntoDeEstados();
            this.estadosFinales = new ConjuntoDeEstados();
            this.estadosIniciales = new ConjuntoDeEstados();
        }

        public void agregarEstado( int num )
        {
            Estado nuevoEstado = new Estado(num);
            this.estados.agregarEstado(nuevoEstado);
        }

        public void declararEstadoInicial( int num)
        {
            Estado nuevoEstado = new Estado(num);
            this.estadosIniciales.agregarEstado(nuevoEstado);
        }

        public void declararEstadoFinal(int num)
        {
            Estado nuevoEstado = new Estado(num);
            this.estadosFinales.agregarEstado(nuevoEstado);
        }

        public Estado getEstadoInicial()
        {
            return estadosIniciales.getEstadoAt(0);
        }
    }
}
