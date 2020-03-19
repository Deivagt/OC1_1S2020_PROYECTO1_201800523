using System;
using System.Collections.Generic;
using System.Text;

namespace OC1_1S2020_PROY1_201800523
{
    public class expresion
    {
        String nombre;
        LinkedList<nodo> lista;

       public expresion(String nombre)
        {
            this.nombre = nombre;
            this.lista = new LinkedList<nodo>();
        }

        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public LinkedList<nodo> getLista()
        {
            return lista;
        }

        public void setLista(LinkedList<nodo> lista)
        {
            this.lista = lista;
        }



    }
}
