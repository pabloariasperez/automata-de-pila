using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leer
{
    public class Alfabeto
    {
        private List<char> elementos;

        public const char LAMBDA  = '$';
        public const char VACIO = '@';

        public Alfabeto(){
            this.elementos = new List<char>();
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
        public override string ToString()
        {
            string tustring = "";
            foreach (char e in elementos)
            {
                tustring += e.ToString() + ", ";
            }
            return tustring;
        }
    }
}