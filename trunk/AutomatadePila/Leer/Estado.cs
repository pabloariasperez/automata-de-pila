using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leer
{
    public class Estado  : IComparable
    {
        private int num;

        public Estado(int num)
        {
            this.num = num;
        }

        public int CompareTo(object objeto)
        {
            if (objeto is Estado)
            {
                Estado elOtroEstado = (Estado)objeto;
                return elOtroEstado.num - this.num;
            }
            else if (objeto is int)
            {
                int numOtroObjeto = (int)objeto;
                return numOtroObjeto - this.num;
            }
            else
            {
                throw new ArgumentException("El objeto dado no es de tipo Estado");
            }
        }
        
    }
}
