using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leer
{
    public class ConjuntoDeEstados
    {
        private List<Estado> estados;

        public ConjuntoDeEstados()
        {
            this.estados = new List<Estado>();
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
        public override string ToString()
        {
            string tustring = "";
            foreach (Estado e in estados)
            {
                tustring += e.ToString() + ", ";
            }
            return tustring;
        }

        /*public int getEstado(int num)
        {
            estados.
        }*/
    }
}
