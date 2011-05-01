using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Leer
{
    class Alfabeto
    {
        private ArrayList elementos;

        public Alfabeto(){
            this.elementos = new ArrayList();
        }

        public bool existeElemento(char elemento){
            return this.elementos.IndexOf(elemento) != -1;
        }

        public void agregarElemento( char nuevoElemento ){
            if (!existeElemento(nuevoElemento))
            {
                this.elementos.Add(nuevoElemento);   
            }
        }

        public int numeroElementos()
        {
            return elementos.Count;
        }
    }
}