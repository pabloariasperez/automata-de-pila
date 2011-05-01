using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Leer
{
    class ConjuntoDeEstados
    {
        private ArrayList estados;

        public ConjuntoDeEstados()
        {
            this.estados = new ArrayList();
        }

        public bool existeEstado(Estado estado)
        {
            return this.estados.IndexOf(estado) != -1;
        }

        public void agregarEstado(Estado nuevoEstado)
        {
            if (!existeEstado(nuevoEstado))
            {
                this.estados.Add(nuevoEstado);
            }
        }

        public int numeroElementos()
        {
            return estados.Count;
        }

        public int getEstado(int num)
        {
            return 1;
        }
    }
}
