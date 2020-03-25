using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OC1_1S2020_PROY1_201800523
{
    

    class listaExpresiones
    {

        String nombre;
        DataTable tablaTransiciones;

        public listaExpresiones(String nombre, DataTable tablaTransiciones)
        {
            this.nombre = nombre;
            this.tablaTransiciones = tablaTransiciones;
        }

        public String getNombre()
        {
            return this.nombre;

        }

        public DataTable getTablaTransiciones()
        {
            return this.tablaTransiciones;
        }
    }
}
