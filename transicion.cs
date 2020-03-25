using System;
using System.Collections.Generic;

namespace OC1_1S2020_PROY1_201800523
{
    class transicion
    {
        String nombre;
        List<int> nodosAlcanza = new List<int>();
        List<nodoThompson> terminalesAlcanza = new List<nodoThompson>();
        nodoThompson nodo;
        bool esFinal = false;
        public transicion(string nombre, nodoThompson nodo)
        {
            this.nombre = nombre;
            this.nodo = nodo;
        }

        public String getNombre()
        {
            return this.nombre;
        }
        public bool getEsFinal()
        {
            return this.esFinal;
        }
        public List<int> getNodosAlcanza()
        {
            return this.nodosAlcanza;
        }

        public nodoThompson getNodo()
        {
            return this.nodo;
        }

        public List<nodoThompson> getTerminalesAlcanza ()
        {
            return this.terminalesAlcanza;
        }

        public void setNodo(nodoThompson nodo)
        {
            this.nodo = nodo;
        }
        public void setEsFinal(bool esFinal)
        {
            this.esFinal = esFinal;
        }
        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public void setNodosAlcanza(List<int> nodosAlcanza)
        {
            this.nodosAlcanza = nodosAlcanza;
        }

        public void setTerminalesAlcanza(List<nodoThompson> terminalesAlcanza)
        {
            this.terminalesAlcanza = terminalesAlcanza;
        }

    }
}
